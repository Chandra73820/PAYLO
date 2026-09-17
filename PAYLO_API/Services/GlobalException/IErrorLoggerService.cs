using PAYLO_Classes.Common;

namespace PAYLO_API.Services.GlobalException
{
    public interface IErrorLoggerService
    {
        void Enqueue(ErrorLogEntry entry);
    }
}
