using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Design_Patterns.Behavioral_DP.Strategy
{
    //This context class contains a property that is used to hold the reference of a Strategy object.
    //This property will be set at run-time by the client according to the algorithm that is required.
    class ContextCompression
    {
        private ICompressFile compressFile;

        public ContextCompression(ICompressFile compressFile)
        {
            this.compressFile = compressFile;
        }

        //setter property.

        public void SetStrategy(ICompressFile compressFile) {

            this.compressFile = compressFile;
        
        }

        public void CreateFiles(string FileName) {

            compressFile.CompressFile( FileName);
        
        }
    }
}
