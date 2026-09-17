using System.Threading.Channels;
using PAYLO_Classes.Common;

namespace PAYLO_API.Services.GlobalException
{
    public class ErrorLoggerService : IErrorLoggerService
    {
        private readonly Channel<ErrorLogEntry> _channel;

        public ErrorLoggerService()
        {
            // Bounded channel — drops oldest if overwhelmed (better than OOM)
            var options = new BoundedChannelOptions(capacity: 1000)
            {
                FullMode = BoundedChannelFullMode.DropOldest,
                SingleReader = true,
                SingleWriter = false
            };
            _channel = Channel.CreateBounded<ErrorLogEntry>(options);
        }

        public void Enqueue(ErrorLogEntry entry)
        {
            // TryWrite is non-blocking; never throws
            _channel.Writer.TryWrite(entry);
        }

        public ChannelReader<ErrorLogEntry> Reader => _channel.Reader;
    }
}
