using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample_Caching_Logging.Custom_Logging
{
    public static class LoggerFileExtension
    {
        public static ILoggingBuilder AddLoggerFile(this ILoggingBuilder builder, Action<LoggerFileOptions> configure) {

            builder.Services.AddSingleton<ILoggerProvider, CustomLoggerFileProvider>();
            builder.Services.Configure(configure);

            return builder;
        
        } 
    }
}
