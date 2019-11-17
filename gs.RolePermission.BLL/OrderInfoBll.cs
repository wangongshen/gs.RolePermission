using gs.RolePermission.DAL;
using gs.RolePermission.DALFactory;
using gs.RolePermission.IBLL;
using gs.RolePermission.IDAL;
using gs.RolePermission.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace gs.RolePermission.BLL
{
    public class OrderInfoBll : BaseBll<OrderInfo>, IOrderInfoBll
    {
        public override void SetCurrentDal()
        {
            CurrentDal = DbSession.OrderInfoDal;
        }
    }
}
