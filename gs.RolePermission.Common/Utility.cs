using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace gs.RolePermission.Common
{
    public class Utility
    {
        /// <summary>
        /// 暂时不管用
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="asObject"></param>
        /// <returns></returns>
        public static T ConvertObject<T>(object asObject) where T : new()
        {
            var serializer = new JavaScriptSerializer();
            //将object对象转换为json字符
            var json = serializer.Serialize(asObject);
            //将json字符转换为实体对象
            var t = serializer.Deserialize<T>(json);
            return t;
        }
    }
}
