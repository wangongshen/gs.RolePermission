using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace gs.RolePermission.Common.Cache
{
    public class HttpRuntimeCacheWriter : ICacheWriter
    {
        public void AddCache(string key, object value, DateTime expDate)
        {
            throw new NotImplementedException();
        }

        public void AddCache(string key, object value)
        {
            throw new NotImplementedException();
        }

        public object GetCache(string key)
        {
            throw new NotImplementedException();
        }

        public T GetCache<T>(string key)
        {
            throw new NotImplementedException();
        }

        public void SetCache(string key, object value, DateTime expDate)
        {
            HttpRuntime.Cache.Remove(key);//先把缓存数据清掉
            AddCache(key, value, expDate);//然后重新加入
        }

        public void SetCache(string key, object value)
        {
            HttpRuntime.Cache.Remove(key);//先把缓存数据清掉
            AddCache(key, value);//然后重新加入
        }
    }
}
