namespace LoggerMicroService.Services
{
    public interface ILoggerService
    {

        void LogDebug(string message);
        void LogError(Exception e, string message);

        void LogInfo(string message);
        void LogWarn(string message);
    }
}
