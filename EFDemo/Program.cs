using gs.RolePermission.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //#region 添加 1
            ////添加数据 EF上下文要对上面的实体做插入操作，要添加对EntityFramework.dll和EntityFramework.SqlServer.dll的引用
            //DataModelContainer dmc = new DataModelContainer();
            //UserInfo user = new UserInfo();
            //user.Uname = "zs";
            //user.Pwd = "123456";
            //user.ShowName = "张三1";
            //dmc.UserInfo.Add(user);
            //dmc.SaveChanges();
            //Console.WriteLine("添加成功");
            //Console.ReadKey();
            //#endregion

            //#region 添加 2
            ////添加数据 EF上下文要对上面的实体做插入操作，要添加对EntityFramework.dll和EntityFramework.SqlServer.dll的引用
            //DataModelContainer dmc = new DataModelContainer();
            //UserInfo user = new UserInfo();
            //user.Uname = "zs";
            //user.Pwd = "123456";
            //user.ShowName = "张三2";
            //dmc.UserInfo.Attach(user);
            //dmc.Entry<UserInfo>(user).State = EntityState.Added;
            //dmc.SaveChanges();
            //Console.WriteLine("添加成功");
            //Console.ReadKey();
            //#endregion


            #region 添加 2
            //添加数据 EF上下文要对上面的实体做插入操作，要添加对EntityFramework.dll和EntityFramework.SqlServer.dll的引用
            DataModelContainer dmc = new DataModelContainer();
            UserInfo user = new UserInfo();
            user.Uname = "zs";
            user.Pwd = "123456";
            user.ShowName = "张三3";
            dmc.UserInfo.Add(user);

            OrderInfo order1 = new OrderInfo();
            order1.Content = "满100元";
            dmc.OrderInfo.Add(order1);

            OrderInfo order2 = new OrderInfo();
            order2.Content = "满100元";
            dmc.OrderInfo.Add(order2);

            user.OrderInfo.Add(order1);
            user.OrderInfo.Add(order2);

            dmc.SaveChanges();
            Console.WriteLine("添加成功");
            Console.ReadKey();
            #endregion


        }
    }
}
