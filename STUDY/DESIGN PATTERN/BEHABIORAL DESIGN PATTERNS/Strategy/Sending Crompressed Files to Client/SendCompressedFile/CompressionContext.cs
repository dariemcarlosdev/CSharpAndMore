using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendCompressedFile
{
    public class CompressionContext
    {
        //Property that hold reference of Strategy Object
        private ICompression Compression;

        //Context receive the Strategy object, and the property will be set at run-time by the CLient according the argorithm that's required.
        public CompressionContext(ICompression compression)
        {
            this.Compression = compression;
        }

        public void SetStrategy( ICompression compression) {

            this.Compression = compression;
        
        }

        public void CreateFile( string CompressedFileName) {

            Compression.CompressFolder(CompressedFileName);
        }
    }
}
