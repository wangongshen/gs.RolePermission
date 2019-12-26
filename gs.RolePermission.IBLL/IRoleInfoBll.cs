using gs.RolePermission.Model;
using gs.RolePermission.Model.Param;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gs.RolePermission.IBLL
{
    public interface IRoleInfoBll:IBaseBll<RoleInfo>
    {

        IQueryable<RoleInfo> LoadPageData(RoleQueryParam roleQueryParam);
    }
}
