using PAYLO_Dal;

namespace PAYLO_API.Services.GlobalException
{
    /// <summary>
    /// Cleanup sweep — hard-revokes refresh tokens left in PendingRevoke state
    /// by the SoftRevoke flow (tab/browser close with no return).
    /// Periodic CLEANUP sweep, NOT a per-client heartbeat.
    /// Same shape as ErrorLogBackgroundProcessor.
    /// </summary>
    public class PendingRevokeCleanup : BackgroundService
    {
        private readonly ILogger<PendingRevokeCleanup> _ilogger;
        private readonly string _env;

        // Tune with the SQL grace window (proc uses DATEADD(SECOND,-30,...))
        private static readonly TimeSpan SweepInterval = TimeSpan.FromSeconds(30);

        public PendingRevokeCleanup(
            ILogger<PendingRevokeCleanup> ilogger,
            IConfiguration config)
        {
            _ilogger = ilogger;
            _env = config.GetValue<string>("Environment") ?? "STAG";
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _ilogger.LogInformation(
                "PendingRevokeCleanup started. Interval={Seconds}s",
                SweepInterval.TotalSeconds);

            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    // ✅ DAL singleton — no scope needed (same as error logger)
                    // Sync DAL call wrapped in Task.Run to free the loop thread
                    var revoked = await Task.Run(() =>
                        PAYLODAL.Instance.CommonService.RevokePendingAsync(_env),
                        stoppingToken);

                    if (revoked > 0)
                        _ilogger.LogInformation(
                            "PendingRevokeCleanup revoked {Count} stale session(s).",
                            revoked);
                }
                catch (OperationCanceledException)
                {
                    break;   // graceful shutdown
                }
                catch (Exception ex)
                {
                    _ilogger.LogWarning(ex, "PendingRevoke cleanup sweep failed.");
                }

                try
                {
                    await Task.Delay(SweepInterval, stoppingToken);
                }
                catch (OperationCanceledException)
                {
                    break;   // shutdown during delay
                }
            }

            _ilogger.LogInformation("PendingRevokeCleanup stopped.");
        }
    }
}
