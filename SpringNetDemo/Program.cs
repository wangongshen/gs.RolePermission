using Spring.Context;
using Spring.Context.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpringNetDemo
{
    public class Program
    {
        static void Main(string[] args)
        {
            #region 传统方式
            ////传统方法
            //IUserInfo info = new UserInfo();
            //info.Show();
            //Console.ReadKey();  
            #endregion

            #region Spring.Net 1
            ////Spring.Net 1
            IApplicationContext ctx = ContextRegistry.GetContext();
            IUserInfo dal = ctx.GetObject("UserInfo") as IUserInfo;
            dal.Show();
            Console.ReadKey();
            #endregion

            //IUserInfo userInfo = new UserInfo("1",1);
            //userInfo.Show();

            //Console.ReadKey();
        }
    }
}
