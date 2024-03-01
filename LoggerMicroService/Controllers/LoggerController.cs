using Microsoft.AspNetCore.Mvc;
using LoggerMicroService.Models;
using LoggerMicroService.Services;

namespace LoggerMicroService.Controllers
{
    [ApiController]
    [Route("api/logger")]// [Route("Logger")]
    public class LoggerController : ControllerBase
    {
        private readonly ILoggerService _loggerService;

        public LoggerController(ILoggerService loggerService)
        { 
            _loggerService = loggerService;
        }

        [HttpPost]
        public IActionResult PostLogMessage([FromBody] Logger log)
        {
            try
            {
                string message = log.Service + " \t" + log.Method + "\t" + log.Message;

                if (log.Level == LogLevel.Information)
                {
                    _loggerService.LogInfo(message);
                }

                else if ( log.Level == LogLevel.Error)
                {
                    _loggerService.LogError(log.Error, message);
                }
                else if (log.Level == LogLevel.Debug)
                {
                    _loggerService.LogDebug(message);
                }
                else if (log.Level == LogLevel.Warning)
                {
                    _loggerService.LogWarn(message);
                }

                return Ok(Task.FromResult("Successfully created the requested log!"));
            }
            catch (Exception e)
            {
                _loggerService.LogError(e, "Caught an error while creating the log file.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Caught an error while creating the log file");
            }
        }

    }
}
