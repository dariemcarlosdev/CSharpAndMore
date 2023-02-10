namespace Sample_Caching
{
    internal class CacheKeys
    {
        public static string Employees { get; set; }
        //public static string Employees => "emp";
         static CacheKeys()
        {
            Employees = "emp";
        }


    }
}