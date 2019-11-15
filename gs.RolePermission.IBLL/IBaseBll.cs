using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace gs.RolePermission.IBLL
{
    public interface IBaseBll<T> where T:class,new ()
    {
        IQueryable<T> GetEntities(Expression<Func<T, bool>> whereLambda);

        IQueryable<T> GetPageEntities<S>(int pageSize, int pageIndex, out int total, Expression<Func<T, bool>> whereLambda, Expression<Func<T, S>> orderByLambda, bool isAsc);

        T Add(T entity);

        bool Update(T entity);

        bool Delete(T entity);
        bool Delete(int id);
        int DeleteList(List<int> ids);
        int DeleteListByLogical(List<int> ids);
    }
}
