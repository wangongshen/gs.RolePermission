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
    public partial class R_UserInfo_ActionInfoBll : BaseBll<R_UserInfo_ActionInfoBll>, IR_UserInfo_ActionInfoBll
    {
        public R_UserInfo_ActionInfo Add(R_UserInfo_ActionInfo entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(R_UserInfo_ActionInfo entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<R_UserInfo_ActionInfo> GetEntities(Expression<Func<R_UserInfo_ActionInfo, bool>> whereLambda)
        {
            throw new NotImplementedException();
        }

        public IQueryable<R_UserInfo_ActionInfo> GetPageEntities<S>(int pageSize, int pageIndex, out int total, Expression<Func<R_UserInfo_ActionInfo, bool>> whereLambda, Expression<Func<R_UserInfo_ActionInfo, S>> orderByLambda, bool isAsc)
        {
            throw new NotImplementedException();
        }

        public override void SetCurrentDal()
        {
            //CurrentDal = DbSession.R_UserInfo_ActionInfoDal;
        }

        public bool Update(R_UserInfo_ActionInfo entity)
        {
            throw new NotImplementedException();
        }
    }
}
