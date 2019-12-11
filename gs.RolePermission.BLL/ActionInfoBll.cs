using gs.RolePermission.IBLL;
using gs.RolePermission.Model;
using gs.RolePermission.Model.Param;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gs.RolePermission.BLL
{
    public class ActionInfoBll : BaseBll<ActionInfo>, IActionInfoBll
    {
        public IQueryable<ActionInfo> LoadPageData(ActionQueryParam actionQueryParam)
        {
            short normalFlag = (short)gs.RolePermission.Model.Enum.DelFlagEnum.Normal;
            //拿到未删除的数据
            var temp = DbSession.ActionInfoDal.GetEntities(u => u.DelFlag == normalFlag);
            //过滤
            if (!string.IsNullOrEmpty(actionQueryParam.SchName))
            {
                temp = temp.Where(u => u.ActionName.Contains(actionQueryParam.SchName)).AsQueryable();
            }
            if (!string.IsNullOrEmpty(actionQueryParam.SchRemark))
            {
                temp = temp.Where(u => u.Remark.Contains(actionQueryParam.SchRemark)).AsQueryable();
            }
            actionQueryParam.Total = temp.Count();
            //分页
            return temp.OrderBy(u => u.Id)
                .Skip(actionQueryParam.PageSize * (actionQueryParam.PageIndex - 1))
                .Take(actionQueryParam.PageSize).AsQueryable();
        }

        public override void SetCurrentDal()
        {
            CurrentDal = this.DbSession.ActionInfoDal;
        }

        public bool SetRole(int actionId, List<int> roleIds)
        {
            //1.获取用户
            var action = DbSession.ActionInfoDal.GetEntities(u => u.Id == actionId).FirstOrDefault();
            //2.设置用户角色：用户的角色是通过导航属性（RoleInfo）来设置
            //2.1把当前用户的原先角色全部删除
            action.RoleInfo.Clear();
            //2.2拿到所有要设置的角色
            var allRoles = DbSession.RoleInfoDal.GetEntities(r => roleIds.Contains(r.Id));
            //2.3通过遍历把所有角色都加入到当前用户
            foreach (var roleInfo in allRoles)
            {
                action.RoleInfo.Add(roleInfo);
            }
            //3.保存到数据库
            DbSession.SaveChanges();
            return true;
        }

   
    }
}
