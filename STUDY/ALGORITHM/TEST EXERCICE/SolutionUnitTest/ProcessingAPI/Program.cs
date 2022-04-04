using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessingAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            var processingAPI = ProcessingAPI("https://localhost:8080/");
            foreach (var item in processingAPI)
            {
                Console.WriteLine(item);
            }
        }
        static List<string> ProcessingAPI(string URL)
        {
            ;
            var IdList = GetListIDS();

            var ApiCorreced = new List<string>();

            foreach (var item in IdList)
            {
                ApiCorreced.Add(URL + item.ToString());
            }

            return ApiCorreced;
        }

        static List<int> GetListIDS()
        {
            return new List<int>() { 12345, 34567, 45687, 78906 };
        }
    }
}
