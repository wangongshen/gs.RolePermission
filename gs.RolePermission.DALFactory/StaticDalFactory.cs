using gs.RolePermission.DAL;
using gs.RolePermission.IDAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace gs.RolePermission.DALFactory
{
    public static class StaticDalFactory
    {
        public static IUserInfoDal GetUserInfoDal()
        {
            //return new UserInfoDal();//简单工厂创建实例代码
            //把上面的new去掉：希望改一个配置那么创建的实例就发生变化，不需要改代码
            string assemblyName = ConfigurationManager.AppSettings["DalAssemblyName"];
            Console.WriteLine(",,,,:"+ assemblyName);
            return Assembly.Load(assemblyName).CreateInstance(assemblyName + ".UserInfoDal") as IUserInfoDal;
        }

        public static IOrderInfoDal GetOrderInfoDal()
        {
            //return new UserInfoDal();//简单工厂创建实例代码
            //把上面的new去掉：希望改一个配置那么创建的实例就发生变化，不需要改代码
            string assemblyName = ConfigurationManager.AppSettings["DalAssemblyName"];
            Console.WriteLine(",,,,:" + assemblyName);
            return Assembly.Load(assemblyName).CreateInstance(assemblyName + ".OrderInfoDal") as IOrderInfoDal;
        }

        public static IActionInfoDal GetActionInfoDal()
        {
            //return new UserInfoDal();//简单工厂创建实例代码 
            //把上面的new去掉：希望改一个配置那么创建的实例就发生变化，不需要改代码
            string assemblyName = ConfigurationManager.AppSettings["DalAssemblyName"];
            Console.WriteLine(",,,,:" + assemblyName);
            return Assembly.Load(assemblyName).CreateInstance(assemblyName + ".ActionInfoDal") as IActionInfoDal;
        }

        public static IRoleInfoDal GetRoleInfoDal()
        {
            //return new UserInfoDal();//简单工厂创建实例代码 
            //把上面的new去掉：希望改一个配置那么创建的实例就发生变化，不需要改代码
            string assemblyName = ConfigurationManager.AppSettings["DalAssemblyName"];
            Console.WriteLine(",,,,:" + assemblyName);
            return Assembly.Load(assemblyName).CreateInstance(assemblyName + ".RoleInfoDal") as IRoleInfoDal;
        }
    }
}
