namespace Sample_Caching.Controllers
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string ProviderName { get; internal set; }
    }
}