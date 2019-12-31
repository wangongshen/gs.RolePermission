using gs.RolePermission.DAL;
using gs.RolePermission.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gs.RolePermission.DALFactory
{
    public class DbSession : IDbSession
    {
        public IUserInfoDal UserInfoDal
        {
            get { return StaticDalFactory.GetUserInfoDal(); }
        }
        public IOrderInfoDal OrderInfoDal
        {
            get { return StaticDalFactory.GetOrderInfoDal(); }
        }

        public IActionInfoDal ActionInfoDal {
            get { return StaticDalFactory.GetActionInfoDal(); }
        }

        public IRoleInfoDal RoleInfoDal
        {
            get { return StaticDalFactory.GetRoleInfoDal(); }
        }
        /// <summary>
        /// 拿到当前EF的上下文对象，然后进行把修改实体进行一个整体提交（简单说该方法就是让上下文提交）
        /// </summary>
        /// <returns></returns>
        public int SaveChanges()
        {
            try
            {
                return DbContentFactory.GetCurrentDbContent().SaveChanges();//需要添加对Entity Framework.dll的引用
            }
            catch (Exception)
            {

                return 1;
            }
           
        }
    }
}
