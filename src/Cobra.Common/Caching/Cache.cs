using Cobra.SharedKernel;
using Cobra.SharedKernel.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using System;

namespace Cobra.Common.Caching
{
    public class Cache<TType> : ICache<TType>
    {
        private readonly IMemoryCache _memoryCache;

        public Cache(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public TType? GetCache(string key)
        {
            _memoryCache.TryGetValue<TType>(key, out var value);
            return value;
        }

        public void SetCache(CacheRequest<TType> data)
        {
            var cacheExpiryOptions = new MemoryCacheEntryOptions
            {
                AbsoluteExpiration = DateTime.Now.AddMinutes(5),
                Priority = CacheItemPriority.High,
                SlidingExpiration = TimeSpan.FromMinutes(2),
                Size = 1024,
            };
            _memoryCache.Set(data.key, data.value, cacheExpiryOptions);
        }
    }
}
