using gs.RolePermission.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using gs.RolePermission.Model;
using gs.RolePermission.IDAL;
using gs.RolePermission.DALFactory;

namespace gs.RolePermission.BLL
{
    public abstract class BaseBll<T> where T:class,new()
    {
        public IBaseDal<T> CurrentDal { get; set; }
        public abstract void SetCurrentDal();
        public BaseBll()//基类的构造方法
        {
            SetCurrentDal();//该方法由子类去实现
        }
        public IQueryable<T> GetEntities(Expression<Func<T, bool>> whereLambda)
        {
            return CurrentDal.GetEntities(whereLambda);
        }

        public IQueryable<T> GetPageEntities<S>(int pageSize, int pageIndex, out int total, Expression<Func<T, bool>> whereLambda, Expression<Func<T, S>> orderByLambda, bool isAsc)
        {
            return CurrentDal.GetPageEntities(pageSize, pageIndex, out total, whereLambda, orderByLambda, isAsc);
        }

        public T Add(T entity)
        {
            ////假设是UserInfoBll继承了这个类，那么这里就应该是
            //return UserInnfoDal.Add(entity);
            ////如果是OrderInfoBll继承了这个类，那么这里就应该是
            //return OrderInfoDal.Add(entity);
            ////所以这里就应该是用当前的Dal——CurrentDal
            //return CurrentDal.Add(entity);
            CurrentDal.Add(entity);
            DbSession.SaveChanges();
            return entity;
        }

        public bool Update(T entity)
        {
            //return CurrentDal.Update(entity);//不能就这个一个return语句，因为这里为IBaseDal类型，而这个类型里的Update方法又来自于BaseDal，而BaseDal下的增删改方法都没有SaveChanges()，没有更新到数据库，所以在业务层这边要更新数据库，即时调用DbSession.SaveChanges()
            CurrentDal.Update(entity);
            return DbSession.SaveChanges() > 0;
        }

        public bool Delete(T entity)
        {
            //return CurrentDal.Delete(entity);
            CurrentDal.Delete(entity);
            return DbSession.SaveChanges() > 0;
        }
        public IDbSession DbSession
        {
            get
            {
                return DbSessionFactory.GetCurrentDbSession();
            }
        }
        public bool Delete(int id)
        {
            CurrentDal.Detete(id);
            return DbSession.SaveChanges() > 0;
        }

        public int DeleteList(List<int> ids)
        {
            foreach (var id in ids)
            {
                CurrentDal.Detete(id);
            }
            return DbSession.SaveChanges();//这里把SaveChanges方法提到了循环体外，自然就与数据库交互一次
        }

        public int DeleteListByLogical(List<int> ids)
        {
            CurrentDal.DeleteListByLogical(ids);
            return DbSession.SaveChanges();
        }
    }
}
