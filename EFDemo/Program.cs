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
            //user.ShowName = "张三123";
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


            //#region 添加 3
            ////添加数据 EF上下文要对上面的实体做插入操作，要添加对EntityFramework.dll和EntityFramework.SqlServer.dll的引用
            //DataModelContainer dmc = new DataModelContainer();
            //UserInfo user = new UserInfo();
            //user.Uname = "zs";
            //user.Pwd = "123456";
            //user.ShowName = "张三3";
            //dmc.UserInfo.Add(user);

            //OrderInfo order1 = new OrderInfo();
            //order1.Content = "满100元";
            //dmc.OrderInfo.Add(order1);

            //OrderInfo order2 = new OrderInfo();
            //order2.Content = "满100元";
            //dmc.OrderInfo.Add(order2);

            //user.OrderInfo.Add(order1);
            //user.OrderInfo.Add(order2);

            //dmc.SaveChanges();
            //Console.WriteLine("添加成功");
            //Console.ReadKey();
            //#endregion

            //#region 修改全部字段 1
            ////添加数据 EF上下文要对上面的实体做插入操作，要添加对EntityFramework.dll和EntityFramework.SqlServer.dll的引用
            //DataModelContainer dmc = new DataModelContainer();
            //UserInfo user = new UserInfo();
            //user.Id = 1;
            //user.Uname = "zs1";
            //user.Pwd = "123456";
            //user.ShowName = "张三3";
            ////泛型写法 修改所有字段
            //dmc.Entry<UserInfo>(user).State = EntityState.Modified;

            //dmc.SaveChanges();
            //Console.WriteLine("修改成功");
            //Console.ReadKey();
            //#endregion

            //#region 修改部分字段 1
            ////添加数据 EF上下文要对上面的实体做插入操作，要添加对EntityFramework.dll和EntityFramework.SqlServer.dll的引用
            //DataModelContainer dmc = new DataModelContainer();
            //UserInfo user = new UserInfo();
            //user.Id = 1;
            //user.Uname = "zs12";
            //user.Pwd = "1234568888";
            //user.ShowName = "张三31";
            ////泛型写法 修改所有字段
            //dmc.UserInfo.Attach(user);
            //dmc.Entry<UserInfo>(user).Property("Pwd").IsModified = true;
            //dmc.Entry<UserInfo>(user).Property("ShowName").IsModified = true;
            //dmc.SaveChanges();
            //Console.WriteLine("修改成功");
            //Console.ReadKey();
            //#endregion

            //#region 删除 1
            ////添加数据 EF上下文要对上面的实体做插入操作，要添加对EntityFramework.dll和EntityFramework.SqlServer.dll的引用
            //DataModelContainer dmc = new DataModelContainer();
            //UserInfo user = new UserInfo();
            //user.Id = 2;
            //dmc.Entry<UserInfo>(user).State = EntityState.Deleted;
            //dmc.SaveChanges();

            //Console.WriteLine("删除成功");
            //Console.ReadKey();
            //#endregion

            //#region 删除 1
            ////添加数据 EF上下文要对上面的实体做插入操作，要添加对EntityFramework.dll和EntityFramework.SqlServer.dll的引用
            //DataModelContainer dmc = new DataModelContainer();
            //UserInfo user = new UserInfo();
            //user.Id = 3;
            //dmc.UserInfo.Attach(user);
            //dmc.UserInfo.Remove(user);
            //dmc.SaveChanges();
            //Console.WriteLine("删除成功");
            //Console.ReadKey();
            //#endregion

            //#region 批量添加
            //DataModelContainer dmc = new DataModelContainer();
            //for (int i = 0; i < 8; i++)
            //{
            //    UserInfo user = new UserInfo();
            //    user.Uname = "王五" + i;
            //    user.Pwd = "12345678";
            //    user.ShowName = "wang" + i;
            //    dmc.UserInfo.Add(user);
            //}
            //dmc.SaveChanges();
            //Console.WriteLine("批量添加成功");
            //Console.ReadKey();
            //#endregion

            //#region foreach遍历
            //DataModelContainer dmc = new DataModelContainer();
            //foreach (var user in dmc.UserInfo)
            //{
            //    Console.WriteLine("姓名："+user.Uname);
            //}
            //Console.ReadKey();
            //#endregion

            //#region foreach遍历
            //DataModelContainer dmc = new DataModelContainer();
            //var data = from u in dmc.UserInfo where u.Id < 6 && u.Uname.StartsWith("z") select u;
            //foreach (var user in data)
            //{
            //    Console.WriteLine("编号："+user.Id+"/n姓名：" + user.Uname);
            //}
            //Console.ReadKey();
            //#endregion

            //#region 延迟加载，用到的时候才去查询数据库
            //DataModelContainer dbCotent = new DataModelContainer();

            //var temp1 = from u in dbCotent.UserInfo
            //            where u.Id < 15
            //            select u;

            //var temp2 = from u in temp1
            //            where u.Id < 10 && u.Uname.Contains("z")
            //            select u;

            ////注意：上面有2个Linq to EF语句，但不会执行2次查询，因为都会延迟到用的时候才查询，所以上面2条查询会合并后才执行查询

            //foreach (var user in temp2)
            //{
            //    Console.WriteLine(user.Id + "  " + user.Uname);
            //}
            //Console.ReadKey();
            //#endregion


            #region 多表查询,通过Include方法取消延迟加载，进行表连接查询，数据量小的时候采用
            DataModelContainer dbCotent = new DataModelContainer();
            //用Include即进行了表连接查询，取消了延迟加载
            var temp = from u in dbCotent.UserInfo.Include("OrderInfo")
                       where u.Id < 15
                       select u;
            //通过导航属性多表查询,没有进行表连接查询
            foreach (var user in temp)
            {
                foreach (var orderInfo in user.OrderInfo)
                {
                    Console.WriteLine(user.Uname + "  " + orderInfo.Id + "  " + orderInfo.Content);
                }
            }
            Console.ReadKey();
            #endregion

        }
    }
}
