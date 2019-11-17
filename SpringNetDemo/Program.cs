using Spring.Context;
using Spring.Context.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpringNetDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 传统方式
            ////传统方法
            //IUserInfo info = new UserInfo();
            //info.Show();
            //Console.ReadKey();  
            #endregion

            //Spring.Net
            IApplicationContext ctx = ContextRegistry.GetContext();
            IUserInfo dal = ctx.GetObject("UserInfo") as IUserInfo;
            dal.Show();
           
            Console.ReadKey();
        }
    }
}
