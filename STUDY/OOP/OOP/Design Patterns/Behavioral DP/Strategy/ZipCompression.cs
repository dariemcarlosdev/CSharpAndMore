using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Design_Patterns.Behavioral_DP.Strategy
{
    class ZipCompression : ICompressFile
    {
        public void CompressFile(string fileName)
        {
            Console.WriteLine("Folder compressed using zip approach -> '" + fileName + ".zip' file is created");

        }
    }
}
