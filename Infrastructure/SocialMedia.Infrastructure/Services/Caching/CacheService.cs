using Microsoft.Extensions.Caching.Distributed;
using SocialMedia.Application.Abstractions.Caching;
using SocialMedia.Application.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Infrastructure.Services.Caching
{
    public class CacheService : ICacheService
    {
        private readonly IDistributedCache _distributedCache;
        public CacheService(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

        public async Task<byte[]> GetAsync(string key) => await _distributedCache.GetAsync(key);

        public async Task<string> GetStringAsync(string key) => await _distributedCache.GetStringAsync(key);

        public async Task RemoveAsync(string key) => await _distributedCache.RemoveAsync(key);

        public async Task SetAsync(string key, byte[] value, double addMinutesToExpire, CacheExpirationType? expirationType)
        {
            switch (expirationType)
            {
                case CacheExpirationType.SlidingExpiration:
                    await _distributedCache.SetAsync(key, value, options: new()
                    {
                        SlidingExpiration = TimeSpan.FromMinutes(addMinutesToExpire)
                    });
                    break;
                case CacheExpirationType.AbsoluteExpiration:
                    await _distributedCache.SetAsync(key, value, options: new()
                    {
                        AbsoluteExpiration = DateTime.Now.AddMinutes(addMinutesToExpire)
                    });
                    break;
                case CacheExpirationType.Both:
                    await _distributedCache.SetAsync(key, value, options: new()
                    {
                        AbsoluteExpiration = DateTime.Now.AddMinutes(addMinutesToExpire),
                        SlidingExpiration = TimeSpan.FromMinutes(addMinutesToExpire)
                    });
                    break;
                default:
                    await _distributedCache.SetAsync(key, value, options: new()
                    {
                        AbsoluteExpiration = DateTime.Now.AddMinutes(addMinutesToExpire)
                    });
                    break;
            }
        }

        public async Task SetStringAsync(string key, string value, double addMinutesToExpire, CacheExpirationType? expirationType)
        {
            switch (expirationType)
            {
                case CacheExpirationType.SlidingExpiration:
                    await _distributedCache.SetStringAsync(key, value, options: new()
                    {
                        SlidingExpiration = TimeSpan.FromMinutes(addMinutesToExpire)
                    });
                    break;
                case CacheExpirationType.AbsoluteExpiration:
                    await _distributedCache.SetStringAsync(key, value, options: new()
                    {
                        AbsoluteExpiration = DateTime.Now.AddMinutes(addMinutesToExpire)
                    });
                    break;
                case CacheExpirationType.Both:
                    await _distributedCache.SetStringAsync(key, value, options: new()
                    {
                        AbsoluteExpiration = DateTime.Now.AddMinutes(addMinutesToExpire * 3),
                        SlidingExpiration = TimeSpan.FromMinutes(addMinutesToExpire / 3)
                    });
                    break;
                default:
                    await _distributedCache.SetStringAsync(key, value, options: new()
                    {
                        AbsoluteExpiration = DateTime.Now.AddMinutes(addMinutesToExpire)
                    });
                    break;
            }
        }
    }
}