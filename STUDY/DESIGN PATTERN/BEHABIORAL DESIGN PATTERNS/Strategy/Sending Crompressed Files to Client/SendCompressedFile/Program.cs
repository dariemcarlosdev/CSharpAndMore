using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendCompressedFile
{
    class Program
    {
        static void Main(string[] args)
        {
            var ctx = new CompressionContext(new ZipCompressionStrategy());
            ctx.CreateFile("DotNetStrategyDesignPattern");

            ctx.SetStrategy(new RarCompressionStrategy());
            ctx.CreateFile("DotNetStrategyDesignPattern");
        }
    }
}
