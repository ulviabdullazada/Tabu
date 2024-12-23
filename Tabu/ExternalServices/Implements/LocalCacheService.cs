﻿using Microsoft.Extensions.Caching.Memory;
using Tabu.ExternalServices.Abstracts;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Tabu.ExternalServices.Implements
{
    public class LocalCacheService(IMemoryCache _cache) : ICacheService
    {
        public async Task<T?> GetAsync<T>(string key)
        {
            T? value = default(T);
            await Task.Run(() =>
            {
                _cache.TryGetValue<T>(key, out value);
            });
            return value;
        }

        public async Task SetAsync<T>(string key, T data, int seconds = 300)
        {
            await Task.Run(() =>
            {
                _cache.Set<T>(key, data, DateTime.Now.AddSeconds(seconds));
            });
        }
    }
}
