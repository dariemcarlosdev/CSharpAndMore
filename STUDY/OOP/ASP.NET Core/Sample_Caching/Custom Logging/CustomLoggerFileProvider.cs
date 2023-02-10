using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Sample_Caching_Logging.Custom_Logging
{
    //ProviderAlias attribute helps us identity the name of the logger provider in appsettings.json.
    [ProviderAlias("FileLoggerProvider")]
    public class CustomLoggerFileProvider : ILoggerProvider //IloggerProvider Interface represent a type that can crate a instance of Ilogger().
    {

        //CustomLoggerFileProvider will inject options that eventually are getting from appsetting.json
        public readonly LoggerFileOptions Options;

        public CustomLoggerFileProvider(IOptions<LoggerFileOptions> options)
        {
            Options = options.Value;
            if (!Directory.Exists(Options.FolderPath))
            {
                Directory.CreateDirectory(Options.FolderPath);
            }
        }

        //this method will create a new instance of Logger class.
        public ILogger CreateLogger(string categoryName)
        {
            return new LoggerFile(this); // Return an new instante of LoggerFile which inherit form Ilogger that create the logger file.
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
