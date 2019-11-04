using gs.RolePermission.DAL;
using gs.RolePermission.DALFactory;
using gs.RolePermission.IDAL;
using gs.RolePermission.Model;
using gs.RolePermission.NHDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gs.RolePermission.BLL
{
    class UserInfoBll
    {
        //IUserInfoDal userInfoDal = new UserInfoDal();
        //IUserInfoDal userInfoDal = new NHUserInfoDal();
        IUserInfoDal userInfoDal = StaticDalFactory.GetUserInfoDal();
        public int Add(UserInfo userInfo)
        {
            return userInfoDal.Add(userInfo);
        }

        public bool Delete(UserInfo userInfo)
        {
            return userInfoDal.Delete(userInfo);
        }
    }
}
