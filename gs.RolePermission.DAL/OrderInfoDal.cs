using gs.RolePermission.IDAL;
using gs.RolePermission.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gs.RolePermission.DAL
{
    public partial class OrderInfoDal : BaseDal<OrderInfo>, IOrderInfoDal
    {
        public int DeleteListByLogical(List<int> ids)
        {
            throw new NotImplementedException();
        }

        public bool Detete(int id)
        {
            throw new NotImplementedException();
        }

        int IBaseDal<OrderInfo>.Add(OrderInfo entity)
        {
            throw new NotImplementedException();
        }
    }
}
