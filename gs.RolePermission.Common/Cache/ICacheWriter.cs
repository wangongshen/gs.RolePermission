using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gs.RolePermission.Common.Cache
{
    public interface ICacheWriter
    {
        void AddCache(string key, object value, DateTime expDate);
        void AddCache(string key, object value);
        object GetCache(string key);
        T GetCache<T>(string key);//有了这个方法约束，上面object GetCache(string key);可以没有，因为泛型T可以表示任何类型。
        void SetCache(string key, object value, DateTime expDate);
        void SetCache(string key, object value);
    }
}
