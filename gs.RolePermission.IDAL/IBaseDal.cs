using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace gs.RolePermission.IDAL
{
    public interface IBaseDal<T> where T:class,new ()
    {

        T GetTById(int id);

        /// <summary>
        /// 查询所有用户信息
        /// </summary>
        /// <returns></returns>
        List<T> GetAllEntities();

        /// <summary>
        /// 查询条件由用户决定（用户可任意输入，也即是可以根据任意条件过滤查询）
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
       IQueryable<T> GetEntities(Expression<Func<T, bool>> whereLambda);

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <typeparam name="S"></typeparam>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="total"></param>
        /// <param name="whereLambda"></param>
        /// <param name="orderByLambda"></param>
        /// <param name="isAsc"></param>
        /// <returns></returns>
        IQueryable<T> GetPageEntities<S>(int pageSize, int pageIndex, out int total, Expression<Func<T, bool>> whereLambda, Expression<Func<T, S>> orderByLambda, bool isAsc);
        /// <summary>
        /// 增
        /// </summary>
        /// <param name="T"></param>
        /// <returns></returns>
        bool Add(T entity);

        /// <summary>
        ///修改
        /// </summary>
        /// <param name="T"></param>
        /// <returns></returns>
        bool Update(T entity);


        /// <summary>
        ///删除 
        /// </summary>
        /// <param name="T"></param>
        /// <returns></returns>
        bool Delete(T entity);

        bool Delete(int id);

        bool Detete(int id);
        int DeleteListByLogical(List<int> ids);

    }
}
