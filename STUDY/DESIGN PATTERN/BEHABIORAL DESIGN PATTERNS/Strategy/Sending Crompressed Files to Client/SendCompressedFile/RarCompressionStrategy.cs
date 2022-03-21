using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendCompressedFile
{
    class RarCompressionStrategy : ICompression
    {
        public void CompressFolder(string compressedArchiveFileName)
        {
            Console.WriteLine("Folder is created using RAR approach: '" + compressedArchiveFileName +".rar' file is created");
        }
    }
}
