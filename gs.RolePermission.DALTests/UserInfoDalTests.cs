using Microsoft.VisualStudio.TestTools.UnitTesting;
using gs.RolePermission.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gs.RolePermission.Model;

namespace gs.RolePermission.DAL.Tests
{
    [TestClass()]
    public class UserInfoDalTests
    {
        [TestMethod()]
        public void AddTest()
        {
            UserInfoDal dal = new UserInfoDal();
            UserInfo user = new UserInfo();
            user.UName = "曹操1103";
            user.Pwd = "123456";
            user.ShowName = "曹阿瞒";
            bool sum = dal.Add(user);
            Assert.AreEqual(true, sum);
        }

        [TestMethod()]
        public void GetAllUserInfoTest()
        {
            UserInfoDal dal = new UserInfoDal();
            var userList=dal.GetAllEntities();
            Console.WriteLine(userList.Count());
            Assert.AreEqual(true,15>userList.Count());
        }
    }
}