using PAYLO_Classes.Common;
using PAYLO_Dal;

namespace PAYLO_API.Services.GlobalException
{
    public class ErrorLogBackgroundProcessor : BackgroundService
    {
        private readonly ErrorLoggerService _loggerService;
        private readonly string _env;
        private readonly ILogger<ErrorLogBackgroundProcessor> _ilogger;

        public ErrorLogBackgroundProcessor(
            ErrorLoggerService loggerService,  // ✅ concrete
            IConfiguration config,
            ILogger<ErrorLogBackgroundProcessor> ilogger)
        {
            _loggerService = loggerService;
            _env = config.GetValue<string>("Environment") ?? "STAG";
            _ilogger = ilogger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _ilogger.LogInformation(
                "ErrorLogBackgroundProcessor started. Environment={Env}", _env);

            await foreach (var entry in
                _loggerService.Reader.ReadAllAsync(stoppingToken))
            {
                try
                {
                    // ✅ Wrap sync DB call — frees async loop thread
                    await Task.Run(() =>
                        PAYLODAL.Instance.CommonService
                            .InsertErrorLog(_env, entry),
                        stoppingToken);
                }
                catch (OperationCanceledException)
                {
                    break;   // graceful shutdown
                }
                catch (Exception ex)
                {
                    _ilogger.LogError(ex,
                        "DB insert failed. CorrelationId={Id} Exception={Msg}",
                        entry.CorrelationId, entry.ExceptionMessage);

                    // ✅ Fallback to file
                    await WriteFallbackAsync(entry);
                }
            }

            _ilogger.LogInformation("ErrorLogBackgroundProcessor stopped.");
        }

        private static async Task WriteFallbackAsync(ErrorLogEntry entry)
        {
            try
            {
                var dir = Path.Combine(AppContext.BaseDirectory, "Logs");
                Directory.CreateDirectory(dir);
                var path = Path.Combine(dir,
                    $"errors_{DateTime.UtcNow:yyyyMMdd}.log");
                var line = $"[{DateTime.UtcNow:o}] {entry.CorrelationId} " +
                           $"{entry.ExceptionType}: {entry.ExceptionMessage}\n";
                await File.AppendAllTextAsync(path, line);
            }
            catch { /* absolute last resort */ }
        }
    }
}
