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
 
        public OrderInfoDal Add(OrderInfoDal entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(OrderInfoDal entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<OrderInfoDal> GetEntities(Expression<Func<OrderInfoDal, bool>> whereLambda)
        {
            throw new NotImplementedException();
        }

        public IQueryable<OrderInfoDal> GetPageEntities<S>(int pageSize, int pageIndex, out int total, Expression<Func<OrderInfoDal, bool>> whereLambda, Expression<Func<OrderInfoDal, S>> orderByLambda, bool isAsc)
        {
            throw new NotImplementedException();
        }

        public override void SetCurrentDal()
        {
            //CurrentDal = DbSession.OrderInfoDal;
            CurrentDal = DbSession.OrderInfoDal;
        }

        public bool Update(OrderInfoDal entity)
        {
            throw new NotImplementedException();
        }
    }
}
