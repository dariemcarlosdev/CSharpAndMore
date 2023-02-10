
using Sample_Caching.Controllers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sample_Caching
{
    public interface ICacheServiceProvider
    {
        public Task<List<Employee>> GetDataCachedResponseAsync();
    }
}