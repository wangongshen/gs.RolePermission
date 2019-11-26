using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gs.RolePermission.Common.Cache
{
    public class RedisCacheWriter : ICacheWriter
    {
        //redis服务IP和端口
        static RedisClient redisClient = new RedisClient("m.xmbygy.com", 6380);
        //private RedisClient redisClient;
        //public RedisCacheWriter()
        //{
        //    redisClient = new RedisClient("127.0.0.1", 6380);
        //    //redisClient.Password = "gs";
        //}

        public void AddCache(string key, object value, DateTime expDate)
        {
           redisClient.Add<object>(key, value, expDate);
        }

        public void AddCache(string key, object value)
        {
            redisClient.Set<object>(key, value);
        }

        public object GetCache(string key)
        {
            return redisClient.Get<object>(key);
        }

        public T GetCache<T>(string key)
        {
            return redisClient.Get<T>(key);
        }

        public void SetCache(string key, object value, DateTime expDate)
        {
            redisClient.Set<object>(key, value);
        }

        public void SetCache(string key, object value)
        {
            redisClient.Set<object>(key, value);
        }
    }
}
