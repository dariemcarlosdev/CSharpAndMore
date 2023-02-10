using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample_Caching_Logging.Custom_Logging
{
    /*
      When outputting log files to text files,
      we will need to set/get the folder path and the format of the log file. 
      This Class store this information.
     */
    public class LoggerFileOptions
    {
        public virtual string FilePath { get; set; }
        public virtual string FolderPath { get; set; }
    }
}
