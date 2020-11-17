using Enyim.Caching;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MemcacheExample
{
    public class CacheService<T>
    {
        private readonly IMemcachedClient _cache;
        public CacheService(IMemcachedClient cache)
        {
            this._cache = cache;
        }

        public async Task Save(string key, List<T> obj)
        {
            await this._cache.AddAsync(key, obj, 5000);
        }

        public async Task<T> Get(string key)
        {
            var result = await this._cache.GetAsync<T>(key);
            if (result != null)
            {
                return result.Value;
            }
            return default;
        }

        public async Task<List<T>> GetList(string key)
        {
            var result = await this._cache.GetAsync<List<T>>(key);
            if (result != null)
            {
                return result.Value;
            }
            return default;
        }
    }
}
