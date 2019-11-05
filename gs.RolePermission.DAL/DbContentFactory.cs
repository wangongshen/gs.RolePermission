using gs.RolePermission.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace gs.RolePermission.DAL
{
    public class DbContentFactory
    {
        public static DbContext GetCurrentDbContent()
        {
            //return new DataModelContainer();
            DbContext db = CallContext.GetData("DbContext") as DbContext;
            //从 CallContext 中检索具有指定key“DbContext”的对象，并强转为DbContext
            if (db == null)//线程在数据槽里面没有此上下文
            {
                db = new DataModelContainer();
                CallContext.SetData("DbContext", db);//放到数据槽中去,DbContext是key，db是value
            }
            return db;
        }
    }
}
