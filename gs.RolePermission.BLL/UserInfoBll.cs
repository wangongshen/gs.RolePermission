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
    public class UserInfoBll : BaseBll<UserInfo>, IUserInfoBll
    {
        //1112
        IDbSession dbSession =DbSessionFactory.GetCurrentDbSsession(); 
        //IUserInfoDal userInfoDal = new UserInfoDal();
        //IUserInfoDal userInfoDal = new NHUserInfoDal();
        IUserInfoDal userInfoDal = StaticDalFactory.GetUserInfoDal();
        public UserInfo Add(UserInfo userInfo)
        {
            //return userInfoDal.Add(userInfo);
            dbSession.UserInfoDal.Add(userInfo);
            dbSession.SaveChanges();
            return userInfo;
        }

        public bool Delete(UserInfo userInfo)
        {
            //return userInfoDal.Delete(userInfo);
            dbSession.UserInfoDal.Delete(userInfo);
            dbSession.SaveChanges();
            return true;
        }

        public override void SetCurrentDal()
        {
            throw new NotImplementedException();
        }
    }
}
