using gs.RolePermission.DALFactory;
using gs.RolePermission.IDAL;
using gs.RolePermission.IBLL;
using gs.RolePermission.Model;
using System;
using gs.RolePermission.Model.Param;
using System.Linq;

namespace gs.RolePermission.BLL
{
    public class UserInfoBll : BaseBll<UserInfo>, IUserInfoBll
    {
        public IQueryable<UserInfo> LoadPageData(UserQueryParam userQueryParam)
        {
            short normalFlag = (short)gs.RolePermission.Model.Enum.DelFlagEnum.Normal;
            //拿到未删除的数据
            var temp = DbSession.UserInfoDal.GetEntities(u => u.DelFlag == normalFlag);
            //过滤
            if (!string.IsNullOrEmpty(userQueryParam.SchName))
            {
                temp = temp.Where(u => u.UName.Contains(userQueryParam.SchName)).AsQueryable();
            }
            if (!string.IsNullOrEmpty(userQueryParam.SchName))
            {
                temp = temp.Where(u => u.Remark.Contains(userQueryParam.SchRemark)).AsQueryable();
            }
            userQueryParam.Total = temp.Count();
            //分页
            return temp.OrderBy(u => u.Id)
                .Skip(userQueryParam.PageSize * (userQueryParam.PageIndex - 1))
                .Take(userQueryParam.PageSize).AsQueryable();
        }

        public override void SetCurrentDal()
        {
            CurrentDal = DbSession.UserInfoDal;
        }
    }
}
