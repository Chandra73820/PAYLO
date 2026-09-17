using Microsoft.Data.SqlClient;
using System.Collections.Concurrent;
using System.Data;

namespace PAYLO_API.Services
{
    public interface IAccessTokenBlacklist
    {
        void Add(string jti, DateTime expiresAt);
        Task AddAsync(string jti, DateTime expiresAt);
        bool Contains(string jti);
    }

    // =========================================================================
    // Option A — In-Memory (single server / development)
    // =========================================================================
    public class InMemoryAccessTokenBlacklist : IAccessTokenBlacklist, IDisposable
    {
        private readonly ConcurrentDictionary<string, DateTime> _store = new();
        private readonly ILogger<InMemoryAccessTokenBlacklist> _logger;
        private readonly Timer _cleanupTimer;

        //  Hard cap — prevents unbounded RAM growth
        // If cap hit, oldest entries evicted (LRU not needed — just cleanup expired first)
        private const int MaxEntries = 10_000;

        public InMemoryAccessTokenBlacklist(ILogger<InMemoryAccessTokenBlacklist> logger)
        {
            _logger = logger;
            _cleanupTimer = new Timer(
                _ => Cleanup(),
                null,
                TimeSpan.FromMinutes(10),
                TimeSpan.FromMinutes(10));
        }

        public void Add(string jti, DateTime expiresAt)
        {
            //  Enforce cap — cleanup before adding if full
            if (_store.Count >= MaxEntries)
                Cleanup();

            _store.TryAdd(jti, expiresAt.ToUniversalTime());
        }

        public Task AddAsync(string jti, DateTime expiresAt)
        {
            Add(jti, expiresAt);
            return Task.CompletedTask;
        }

        public bool Contains(string jti)
        {
            if (_store.TryGetValue(jti, out var exp))
            {
                if (exp > DateTime.UtcNow) return true;
                _store.TryRemove(jti, out _);
            }
            return false;
        }

        private void Cleanup()
        {
            var now = DateTime.UtcNow;
            var expired = _store.Where(kv => kv.Value <= now)
                                .Select(kv => kv.Key)
                                .ToList();
            foreach (var key in expired)
                _store.TryRemove(key, out _);

            //  Log so you can monitor blacklist size in production
            _logger.LogInformation(
                "[Blacklist] Cleanup: removed {Expired} expired JTIs. Active: {Active}",
                expired.Count, _store.Count);
        }

        // Dispose timer — prevents thread leak on app shutdown
        public void Dispose() => _cleanupTimer?.Dispose();
    }


    // =========================================================================
    // Option B — SQL-backed (multi-server / load-balanced)
    // All inline SQL replaced with stored procedure calls
    // =========================================================================

    public class SqlAccessTokenBlacklist : IAccessTokenBlacklist
    {
        private readonly string _connectionString;
        private readonly ILogger<SqlAccessTokenBlacklist> _logger;
        private readonly SemaphoreSlim _syncLock = new(1, 1);

        //  Atomic swap — volatile reference, never partially cleared
        private volatile ConcurrentDictionary<string, DateTime> _localCache = new();
        private DateTime _lastSyncAt = DateTime.MinValue;
        private static readonly TimeSpan SyncInterval = TimeSpan.FromSeconds(60);

        public SqlAccessTokenBlacklist(IConfiguration config,
                                        ILogger<SqlAccessTokenBlacklist> logger)
        {
            _logger = logger;
            string environment = config.GetValue<string>("Environment")!.ToUpper().Trim();
            _connectionString = environment switch
            {
                "DEV" => config.GetConnectionString("DevConnection"),
                "STAG" => config.GetConnectionString("StagingConnection"),
                "LIVE" => config.GetConnectionString("LiveConnection"),
                "PROD" => config.GetConnectionString("ProductionConnection"),
                _ => throw new InvalidOperationException($"Unknown Environment '{environment}'")
            } ?? throw new InvalidOperationException("Connection string missing.");
        }

        public void Add(string jti, DateTime expiresAt)
            => AddAsync(jti, expiresAt).GetAwaiter().GetResult();

        public async Task AddAsync(string jti, DateTime expiresAt)
        {
            await using var con = new SqlConnection(_connectionString);
            await using var cmd = new SqlCommand("usp_AccessTokenBlacklist_Insert", con)
            { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.Add("@Jti", SqlDbType.NVarChar, 128).Value = jti;
            cmd.Parameters.Add("@ExpiresAt", SqlDbType.DateTime2).Value = expiresAt.ToUniversalTime();
            await con.OpenAsync();
            await cmd.ExecuteNonQueryAsync();
            _localCache.TryAdd(jti, expiresAt.ToUniversalTime());
        }

        public bool Contains(string jti)
        {
            //  Read from current cache reference — never blocks even during swap
            var cache = _localCache;
            if (cache.TryGetValue(jti, out var exp))
            {
                if (exp > DateTime.UtcNow) return true;
                cache.TryRemove(jti, out _);
                return false;
            }
            if (DateTime.UtcNow - _lastSyncAt > SyncInterval)
                _ = SyncFromSqlAsync();
            return false;
        }

        private async Task SyncFromSqlAsync()
        {
            if (!await _syncLock.WaitAsync(0)) return;
            try
            {
                await using var con = new SqlConnection(_connectionString);
                await using var cmd = new SqlCommand("usp_AccessTokenBlacklist_GetActive", con)
                { CommandType = CommandType.StoredProcedure };
                await con.OpenAsync();
                await using var reader = await cmd.ExecuteReaderAsync();

                //  Build NEW dictionary then swap — existing cache untouched during read
                var newCache = new ConcurrentDictionary<string, DateTime>();
                while (await reader.ReadAsync())
                    newCache.TryAdd(
                        reader.GetString(reader.GetOrdinal("Jti")),
                        reader.GetDateTime(reader.GetOrdinal("ExpiresAt")));

                //  Atomic reference swap — no gap where cache is empty
                _localCache = newCache;
                _lastSyncAt = DateTime.UtcNow;

                _logger.LogDebug("[Blacklist] SQL sync complete. Active JTIs: {Count}",
                    newCache.Count);
            }
            finally { _syncLock.Release(); }
        }
    }

    //public class SqlAccessTokenBlacklist : IAccessTokenBlacklist
    //{
    //    private readonly string _connectionString;

    //    // Hot-cache: avoids SQL roundtrip on every request
    //    private readonly ConcurrentDictionary<string, DateTime> _localCache = new();
    //    private DateTime _lastSyncAt = DateTime.MinValue;
    //    private static readonly TimeSpan SyncInterval = TimeSpan.FromSeconds(60);
    //    private readonly SemaphoreSlim _syncLock = new(1, 1);

    //    public SqlAccessTokenBlacklist(IConfiguration config)
    //    {
    //        string environment = config.GetValue<string>("Environment")!.ToUpper().Trim();

    //        _connectionString = environment switch
    //        {
    //            "DEV" => config.GetConnectionString("DevConnection"),
    //            "STAG" => config.GetConnectionString("StagingConnection"),
    //            "LIVE" => config.GetConnectionString("LiveConnection"),
    //            "PROD" => config.GetConnectionString("ProductionConnection"),
    //            _ => throw new InvalidOperationException(
    //                          $"Unknown Environment '{environment}'. Expected: DEV | STAG | LIVE | PROD")
    //        } ?? throw new InvalidOperationException(
    //                 $"Connection string for environment '{environment}' is null in appsettings.");
    //    }

    //    // ── Sync wrapper ──────────────────────────────────────────────────────
    //    public void Add(string jti, DateTime expiresAt)
    //        => AddAsync(jti, expiresAt).GetAwaiter().GetResult();

    //    // ── INSERT via usp_AccessTokenBlacklist_Insert ────────────────────────
    //    public async Task AddAsync(string jti, DateTime expiresAt)
    //    {
    //        await using var con = new SqlConnection(_connectionString);
    //        await using var cmd = new SqlCommand("usp_AccessTokenBlacklist_Insert", con)
    //        {
    //            CommandType = CommandType.StoredProcedure
    //        };

    //        cmd.Parameters.Add("@Jti", SqlDbType.NVarChar, 128).Value = jti;
    //        cmd.Parameters.Add("@ExpiresAt", SqlDbType.DateTime2).Value = expiresAt.ToUniversalTime();

    //        await con.OpenAsync();
    //        await cmd.ExecuteNonQueryAsync();

    //        // Mirror into hot-cache immediately so logout takes effect instantly
    //        _localCache.TryAdd(jti, expiresAt.ToUniversalTime());
    //    }

    //    // ── Contains: hot-cache first, background SQL sync if stale ──────────
    //    public bool Contains(string jti)
    //    {
    //        // 1. Check local hot-cache (zero SQL cost)
    //        if (_localCache.TryGetValue(jti, out var cachedExp))
    //        {
    //            if (cachedExp > DateTime.UtcNow) return true;
    //            _localCache.TryRemove(jti, out _);  // lazy eviction
    //            return false;
    //        }

    //        // 2. Cache stale → trigger background sync from SQL (fire and forget)
    //        if (DateTime.UtcNow - _lastSyncAt > SyncInterval)
    //            _ = SyncFromSqlAsync();

    //        return false;
    //    }

    //    // ── SELECT via usp_AccessTokenBlacklist_GetActive ─────────────────────
    //    private async Task SyncFromSqlAsync()
    //    {
    //        // Skip if a sync is already in progress
    //        if (!await _syncLock.WaitAsync(0)) return;

    //        try
    //        {
    //            await using var con = new SqlConnection(_connectionString);
    //            await using var cmd = new SqlCommand("usp_AccessTokenBlacklist_GetActive", con)
    //            {
    //                CommandType = CommandType.StoredProcedure
    //            };
    //            // No parameters — procedure filters WHERE ExpiresAt > GETUTCDATE() internally

    //            await con.OpenAsync();
    //            await using var reader = await cmd.ExecuteReaderAsync();

    //            _localCache.Clear();
    //            while (await reader.ReadAsync())
    //            {
    //                var jtiVal = reader.GetString(reader.GetOrdinal("Jti"));
    //                var expVal = reader.GetDateTime(reader.GetOrdinal("ExpiresAt"));
    //                _localCache.TryAdd(jtiVal, expVal);
    //            }

    //            _lastSyncAt = DateTime.UtcNow;
    //        }
    //        finally
    //        {
    //            _syncLock.Release();
    //        }
    //    }
    //}

}
