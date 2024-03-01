using Serilog;

namespace LoggerMicroService.Services
{
    public class LoggerService : ILoggerService
    {

        public void LogDebug(string message)
        {
            Log.Information("The following message was received: {@message}", message);
        }

        public void LogError(Exception e, string message)
        {
            Log.Error("An error occurred: {@e};" +
                "With message: {@message}", e, message);
        }

        public void LogInfo(string message)
        {
            Log.Information("The following message was received: {@message}", message);
        }

        public void LogWarn(string message)
        {
            Log.Information("The following message was received: {@message}", message);
        }
    }
}
