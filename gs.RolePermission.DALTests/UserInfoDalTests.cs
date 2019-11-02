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
            user.Uname = "曹操";
            user.Pwd = "123456";
            user.ShowName = "曹阿瞒";
            int sum = dal.Add(user);
            Assert.AreEqual(1, sum);
        }

        [TestMethod()]
        public void GetAllUserInfoTest()
        {
            UserInfoDal dal = new UserInfoDal();
            var userList=dal.GetAllUserInfo();
            Console.WriteLine(userList.Count());
            Assert.AreEqual(true,15>userList.Count());
        }
    }
}