using gs.RolePermission.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace gs.RolePermission.DAL
{
    /// <summary>
    /// 使用的是泛型约束，约束T是一个类，且有无参构造方法。这样子类在继承该类时就需要传入一个具体的T类型。
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseDal<T> where T:class,new() 
    {
        //DataModelContainer dmc = new DataModelContainer();
        public DbContext dmc
        {
            //保证线程内共享一个上下文实例
            get { return DbContentFactory.GetCurrentDbContent(); }
        }

        /// <summary>
        /// 根据Id查询用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T GetTById(int id)
        {
            return dmc.Set<T>().Find(id);
        }

        /// <summary>
        /// 查询所有用户信息
        /// </summary>
        /// <returns></returns>
        public List<T> GetAllEntities()
        {
            return dmc.Set<T>().ToList();//ToList转为泛型集合，会立刻执行查询，将数据存入内存
        }

        /// <summary>
        /// 查询条件由用户决定（用户可任意输入，也即是可以根据任意条件过滤查询）
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        public IQueryable<T> GetEntities(Expression<Func<T, bool>> whereLambda)
        {
            return dmc.Set<T>().Where(whereLambda).AsQueryable();
        }

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
        public IQueryable<T> GetPageEntities<S>(int pageSize, int pageIndex, out int total, Expression<Func<T, bool>> whereLambda, Expression<Func<T, S>> orderByLambda, bool isAsc)
        {
            total = dmc.Set<T>().Where(whereLambda).Count();
            if (isAsc)
            {
                var pageData = dmc.Set<T>().Where(whereLambda)
                              .OrderBy<T, S>(orderByLambda)
                              .Skip(pageSize * (pageIndex - 1))
                              .Take(pageSize).AsQueryable();
                return pageData;
            }
            else
            {
                var pageData = dmc.Set<T>().Where(whereLambda)
                                 .OrderByDescending<T, S>(orderByLambda)
                                 .Skip(pageSize * (pageIndex - 1))
                                 .Take(pageSize).AsQueryable();
                return pageData;
            }
        }

        /// <summary>
        /// 增
        /// </summary>
        /// <param name="T"></param>
        /// <returns></returns>
        public bool Add(T entity)
        {
            dmc.Set<T>().Add(entity);

            return true;
        }

        /// <summary>
        ///修改
        /// </summary>
        /// <param name="T"></param>
        /// <returns></returns>
        public bool Update(T entity)
        {
            //所有字段均修改
            dmc.Entry<T>(entity).State = System.Data.Entity.EntityState.Modified;
            //return dmc.SaveChanges() > 0;
            return true;
        }


        /// <summary>
        ///删除 
        /// </summary>
        /// <param name="T"></param>
        /// <returns></returns>
        public bool Delete(T entity)
        {
            dmc.Entry<T>(entity).State = System.Data.Entity.EntityState.Deleted;
            //return dmc.SaveChanges() > 0;
            return true;
        }

        public bool Delete(int id)
        {
            dmc.Entry(id).State = System.Data.Entity.EntityState.Deleted;
            //return dmc.SaveChanges() > 0;
            return true;
        }

        public bool Detete(int id)
        {
            var entity = dmc.Set<T>().Find(id);//根据id找到实体
            dmc.Set<T>().Remove(entity);//由于这里先Find找到了实体，所以这里可以用Remove标记该实体要移除（删除）。如果不是先Find到实体就需要用System.Data.Entity.EntityState.Deleted
            return true;
        }
        public int DeleteListByLogical(List<int> ids)
        {
            //foreach (var id in ids)
            //{
            //    var entity = dmc.Set<T>().Find(id);

            //    dmc.Entry(entity).Property("DelFlag").CurrentValue = (short)gs.RolePermission.Model.Enum.DelFlagEnum.Deleted;
            //    dmc.Entry(entity).Property("DelFlag").IsModified = true;//把DelFlag列标记为修改状态，而且这样写死了就要求所有实体都应该有DelFlag属性
            //}
            return 1;
        }
    }
}
