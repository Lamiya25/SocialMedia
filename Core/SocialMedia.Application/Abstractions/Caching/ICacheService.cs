using SocialMedia.Application.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Application.Abstractions.Caching
{
    public interface ICacheService
    {
        Task SetStringAsync(string key, string value, double addMinutesToExpire, CacheExpirationType? expirationType);
        Task SetAsync(string key, byte[] value, double addMinutesToExpire, CacheExpirationType? expirationType);
        Task<string> GetStringAsync(string key);
        Task<byte[]> GetAsync(string key);
        Task RemoveAsync(string key);
    }
}