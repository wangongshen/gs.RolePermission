using Spring.Context;
using Spring.Context.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gs.RolePermission.Common.Cache
{
    public class CacheHelper
    {
        public static ICacheWriter CacheWriter { get; set; }
        static CacheHelper()
        {
            //走一个容器来创建一个CacheWriter实例、初始化Spring.net
            IApplicationContext ctx = ContextRegistry.GetContext();
            //ctx.GetObject("CacheWriter");
            CacheHelper.CacheWriter = ctx.GetObject("MemcacheWriter") as ICacheWriter;
        }
        public static void AddCache(string key, object value, DateTime expDate)
        {
            //往缓存里写，有可能是单机版、分布式的（又可能是Memcache，Redis）。观察者模式可以实现的。希望通过修改一下配置，就能实现切换
            //用Spring.Net直接注入一个Cache的实现过来，这就必须就得有接口，创建一个ICacheWriter
            //往缓存里写，有可能是单机版、分布式的（又可能是Memcache，Redis）。观察者模式可以实现的。希望通过修改一下配置，就能实现切换
            //早前没有通过Spring.net注入属性的写法，通过new出实例来
            //ICacheWriter cacheWriter = new HttpRuntimeCacheWriter();
            //ICacheWriter cacheWriter = new MemcacheWriter();
            //用Spring.Net直接注入一个Cache的实现过来，而通过Spring注入属性，属性一般都是接口类型，因此先创建一个ICacheWriter
            CacheWriter.AddCache(key, value, expDate);
        }
        //没有过期参数，表示用不过期
        public static void AddCache(string key, object value)
        {
            CacheWriter.AddCache(key, value);
        }
        public static object GetCache(string key)
        {
            return CacheWriter.GetCache(key);
        }

        public static void SetCache(string key, object value, DateTime expDate)
        {
            CacheWriter.SetCache(key, value, expDate);
        }

        //没有过期参数，表示用不过期
        public static void SetCache(string key, object value)
        {
            CacheWriter.SetCache(key, value);
        }
    }
}
