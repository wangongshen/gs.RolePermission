using gs.RolePermission.IBLL;
using gs.RolePermission.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace gs.RolePermission.BLL
{
    public partial class R_UserInfo_ActionInfoBll : BaseBll<R_UserInfo_ActionInfo>, IR_UserInfo_ActionInfoBll
    {
      
        public override void SetCurrentDal()
        {
            CurrentDal = DbSession.R_UserInfo_ActionInfoDal;
        }
    }
}
