using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Design_Patterns.Behavioral_DP.Strategy
{
    class RarCompression : ICompressFile
    {

        public void CompressFile(string fileName)
        {
            Console.WriteLine("Folder compressed using rar approach -> '" + fileName + ".zip' file is created");
        }
    }
}
