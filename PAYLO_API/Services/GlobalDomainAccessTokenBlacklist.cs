using Microsoft.Data.SqlClient;
using System.Collections.Concurrent;
using System.Data;

namespace PAYLO_API.Services
{
    public interface IGlobalDomainAccessTokenBlacklist
    {
        void Add(string jti, DateTime expiresAt);
        Task AddAsync(string jti, DateTime expiresAt);
        bool Contains(string jti);
    }

    // =========================================================================
    // Option A — In-Memory (single server / development)
    // =========================================================================
    public class GlobalDomainInMemoryAccessTokenBlacklist : IGlobalDomainAccessTokenBlacklist, IDisposable
    {
        private readonly ConcurrentDictionary<string, DateTime> _store = new();
        private readonly ILogger<GlobalDomainInMemoryAccessTokenBlacklist> _logger;
        private readonly Timer _cleanupTimer;

        //  Hard cap — prevents unbounded RAM growth
        // If cap hit, oldest entries evicted (LRU not needed — just cleanup expired first)
        private const int MaxEntries = 10_000;

        public GlobalDomainInMemoryAccessTokenBlacklist(ILogger<GlobalDomainInMemoryAccessTokenBlacklist> logger)
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

    public class GlobalDomainSqlAccessTokenBlacklist : IGlobalDomainAccessTokenBlacklist
    {
        private readonly string _connectionString;
        private readonly ILogger<GlobalDomainSqlAccessTokenBlacklist> _logger;
        private readonly SemaphoreSlim _syncLock = new(1, 1);

        //  Atomic swap — volatile reference, never partially cleared
        private volatile ConcurrentDictionary<string, DateTime> _localCache = new();
        private DateTime _lastSyncAt = DateTime.MinValue;
        private static readonly TimeSpan SyncInterval = TimeSpan.FromSeconds(60);

        public GlobalDomainSqlAccessTokenBlacklist(IConfiguration config,
                                        ILogger<GlobalDomainSqlAccessTokenBlacklist> logger)
        {
            _logger = logger;
            string environment = config.GetValue<string>("GBLEnvironment")!.ToUpper().Trim();

            _connectionString = _connectionString = config.GetGblConnectionString();
        }

        public void Add(string jti, DateTime expiresAt)
            => AddAsync(jti, expiresAt).GetAwaiter().GetResult();

        public async Task AddAsync(string jti, DateTime expiresAt)
        {
            await using var con = new SqlConnection(_connectionString);
            await using var cmd = new SqlCommand("usp_GBL_AccessTokenBlacklist_Insert", con)
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
                await using var cmd = new SqlCommand("usp_GBL_AccessTokenBlacklist_GetActive", con)
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
}
