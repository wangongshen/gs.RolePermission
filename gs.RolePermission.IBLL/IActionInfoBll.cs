using gs.RolePermission.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace gs.RolePermission.IBLL
{
    public interface IActionInfoBll : IBaseBll<ActionInfo>
    {
        IQueryable<ActionInfo> LoadPageData(Model.Param.ActionQueryParam actionQueryParam);
        bool SetRole(int uId, List<int> setRoleIdList);

    }
}
