using gs.RolePermission.IDAL;
using gs.RolePermission.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace gs.RolePermission.DAL
{
    public class UserInfoDal:BaseDal<UserInfo>,IUserInfoDal
    {
        //DataModelContainer dmc = new DataModelContainer();
        ///// <summary>
        ///// 根据Id查询用户
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //public UserInfo GetUserInfoById(int id) {

        //    return dmc.UserInfo.Find(id);
        //}

        ///// <summary>
        ///// 查询所有用户信息
        ///// </summary>
        ///// <returns></returns>
        //public List<UserInfo> GetAllUserInfo()
        //{
        //    return dmc.UserInfo.ToList();//ToList转为泛型集合，会立刻执行查询，将数据存入内存
        //}

        ///// <summary>
        ///// 查询条件由用户决定（用户可任意输入，也即是可以根据任意条件过滤查询）
        ///// </summary>
        ///// <param name="whereLambda"></param>
        ///// <returns></returns>
        //public IQueryable<UserInfo> GetUsers(Expression<Func<UserInfo, bool>> whereLambda)
        //{
        //    return dmc.UserInfo.Where(whereLambda).AsQueryable();
        //}

        ///// <summary>
        ///// 分页查询
        ///// </summary>
        ///// <typeparam name="S"></typeparam>
        ///// <param name="pageSize"></param>
        ///// <param name="pageIndex"></param>
        ///// <param name="total"></param>
        ///// <param name="whereLambda"></param>
        ///// <param name="orderByLambda"></param>
        ///// <param name="isAsc"></param>
        ///// <returns></returns>
        //public IQueryable<UserInfo> GetPageUsers<S>(int pageSize, int pageIndex, out int total, Expression<Func<UserInfo, bool>> whereLambda, Expression<Func<UserInfo, S>> orderByLambda, bool isAsc)
        //{
        //    total = dmc.UserInfo.Where(whereLambda).Count();
        //    if (isAsc)
        //    {
        //        var pageData = dmc.UserInfo.Where(whereLambda)
        //                      .OrderBy<UserInfo, S>(orderByLambda)
        //                      .Skip(pageSize * (pageIndex - 1))
        //                      .Take(pageSize).AsQueryable();
        //        return pageData;
        //    }
        //    else
        //    {
        //        var pageData = dmc.UserInfo.Where(whereLambda)
        //                         .OrderByDescending<UserInfo, S>(orderByLambda)
        //                         .Skip(pageSize * (pageIndex - 1))
        //                         .Take(pageSize).AsQueryable();
        //        return pageData;
        //    }
        //}

        ///// <summary>
        ///// 增
        ///// </summary>
        ///// <param name="userInfo"></param>
        ///// <returns></returns>
        //public int Add(UserInfo userInfo)
        //{
        //    dmc.UserInfo.Add(userInfo);
        //    try
        //    {

        //        return dmc.SaveChanges();
        //    }
        //    catch (Exception)
        //    {
        //        return 0;
        //        throw;
        //    }
           
        //}

        ///// <summary>
        /////修改
        ///// </summary>
        ///// <param name="userInfo"></param>
        ///// <returns></returns>
        //public bool Update(UserInfo userInfo)
        //{
        //    //所有字段均修改
        //    dmc.Entry<UserInfo>(userInfo).State = System.Data.Entity.EntityState.Modified;
        //    return dmc.SaveChanges() > 0;
        //}
        

        ///// <summary>
        /////删除 
        ///// </summary>
        ///// <param name="userInfo"></param>
        ///// <returns></returns>
        //public bool Delete(UserInfo userInfo)
        //{
        //    dmc.Entry<UserInfo>(userInfo).State = System.Data.Entity.EntityState.Deleted;
        //    return dmc.SaveChanges() > 0;
        //}
    }
}
