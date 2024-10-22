using MusicShop.Business.Interface;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MusicShop.Business.Concrete
{
    public class RedisCacheService : ICacheService
    {
        private readonly IConnectionMultiplexer _connectionMultiplexer;


        public RedisCacheService(IConnectionMultiplexer connectionMultiplexer)
        {
            _connectionMultiplexer = connectionMultiplexer;
        }

        public async Task<T> GetAsync<T>(string key)
        {
            var db = _connectionMultiplexer.GetDatabase();
            var value = await db.StringGetAsync(key);
            if(value.IsNullOrEmpty)
            {
                return default(T);
            }
            return JsonSerializer.Deserialize<T>(value);
        }

        public async Task SetAsync<T>(string key, T value, TimeSpan expiration)
        {
            var db = _connectionMultiplexer.GetDatabase();
            var serializedValue = JsonSerializer.Serialize(value);
            await db.StringSetAsync(key, serializedValue, expiration);
        }
    }
}
