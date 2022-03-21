using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendCompressedFile
{
    class ZipCompressionStrategy : ICompression
    {
        public void CompressFolder(string compressedArchiveFileName)
        {
            Console.WriteLine("Folder is created using ZIP approach: '" + compressedArchiveFileName + ".zip' file is created.");
        }
    }
}
