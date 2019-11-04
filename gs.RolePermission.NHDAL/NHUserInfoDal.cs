using gs.RolePermission.DAL;
using gs.RolePermission.IDAL;
using gs.RolePermission.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace gs.RolePermission.NHDAL
{
    public class NHUserInfoDal : IBaseDal<UserInfo>,IUserInfoDal
    {
        public int Add(UserInfo entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(UserInfo entity)
        {
            throw new NotImplementedException();
        }

        public List<UserInfo> GetAllEntities()
        {
            throw new NotImplementedException();
        }

        public IQueryable<UserInfo> GetEntities(Expression<Func<UserInfo, bool>> whereLambda)
        {
            throw new NotImplementedException();
        }

        public IQueryable<UserInfo> GetPageEntities<S>(int pageSize, int pageIndex, out int total, Expression<Func<UserInfo, bool>> whereLambda, Expression<Func<UserInfo, S>> orderByLambda, bool isAsc)
        {
            throw new NotImplementedException();
        }

        public UserInfo GetTById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(UserInfo entity)
        {
            throw new NotImplementedException();
        }
    }
}
