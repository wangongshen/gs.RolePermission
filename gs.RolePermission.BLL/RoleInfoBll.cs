using gs.RolePermission.IBLL;
using gs.RolePermission.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XDZ.RolePermission.Model.Param;

namespace gs.RolePermission.BLL
{
    public partial class RoleInfoBll : BaseBll<RoleInfo>, IRoleInfoBll
    {
        public IQueryable<RoleInfo> LoadPageData(RoleQueryParam roleQueryParam)
        {
            short normalFlag = (short)gs.RolePermission.Model.Enum.DelFlagEnum.Normal;
            //拿到未删除的数据
            var temp = DbSession.RoleInfoDal.GetEntities(u => u.DelFlag == normalFlag);
            //过滤
            if (!string.IsNullOrEmpty(roleQueryParam.SchName))
            {
                temp = temp.Where(u => u.RoleName.Contains(roleQueryParam.SchName)).AsQueryable();
            }
            if (!string.IsNullOrEmpty(roleQueryParam.SchRemark))
            {
                temp = temp.Where(u => u.Remark.Contains(roleQueryParam.SchRemark)).AsQueryable();
            }
            roleQueryParam.Total = temp.Count();
            //分页
            return temp.OrderBy(u => u.Id)
                .Skip(roleQueryParam.PageSize * (roleQueryParam.PageIndex - 1))
                .Take(roleQueryParam.PageSize).AsQueryable();
        }

        public override void SetCurrentDal()
        {
            throw new NotImplementedException();
        }
    }
}
