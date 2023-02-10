using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Threading.Tasks;

namespace Sample_Caching_Logging.Custom_Logging
{
    //LoggerFile class inherit from Ilogger interface, and it allows to do what we want with this log event.
    internal class LoggerFile : ILogger
    {
        private readonly CustomLoggerFileProvider _customLoggerFileProvider;

        //The constructor receive the CustomLoggerFileProvider as parameter, and it is called in the CreateLogger() method in the CustomLoggerFileProvider class.
        public LoggerFile([NotNull] CustomLoggerFileProvider customLoggerFileProvider)
        {
            _customLoggerFileProvider = customLoggerFileProvider;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        //Check if LogLevel enum in Microsoft.Extensions.Logging is anable.
        public bool IsEnabled(LogLevel logLevel)
        {
            return logLevel != LogLevel.None;
        }

        //Check if LogLevel enum in Microsoft.Extensions.Logging is anable..
        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (!IsEnabled(logLevel))
            {
                return;
            }

            var fullFilePath = _customLoggerFileProvider.Options.FolderPath + "/" + _customLoggerFileProvider.Options.FilePath.Replace("{date}", DateTimeOffset.UtcNow.ToString("yyyyMMdd"));
            var logRecord = string.Format("{0} [{1}] {2} {3}", "[" + DateTimeOffset.UtcNow.ToString("yyyy-MM-dd HH:mm:ss+00:00") + "]", logLevel.ToString(), formatter(state, exception), exception != null ? exception.StackTrace : "");

            
            using ( var streamWriter = new StreamWriter(fullFilePath, true, System.Text.Encoding.UTF8, bufferSize: 3000))

            {
                streamWriter.WriteLine(logRecord);
                
            }

           
        }
    }

}
 
