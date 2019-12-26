using gs.RolePermission.Model.Param;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gs.RolePermission.Model.Param
{
    public class RoleQueryParam:BaseParam
    {
        public string SchName { get; set; }
        public string SchRemark { get; set; }
    }
}
