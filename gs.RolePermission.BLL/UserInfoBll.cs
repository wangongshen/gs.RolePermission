using gs.RolePermission.DALFactory;
using gs.RolePermission.IDAL;
using gs.RolePermission.IBLL;
using gs.RolePermission.Model;
using System;

namespace gs.RolePermission.BLL
{
    public class UserInfoBll : BaseBll<UserInfo>, IUserInfoBll
    {
        public override void SetCurrentDal()
        {
            CurrentDal = DbSession.UserInfoDal;
        }
    }
}
