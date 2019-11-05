using Microsoft.VisualStudio.TestTools.UnitTesting;
using gs.RolePermission.DALFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gs.RolePermission.DALFactory.Tests
{
    [TestClass()]
    public class StaticDalFactoryTests
    {
        [TestMethod()]
        public void GetUserInfoDalTest1()
        {
            StaticDalFactory.GetUserInfoDal();

        }
    }
}