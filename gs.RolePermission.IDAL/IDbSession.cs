using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gs.RolePermission.IDAL
{
    public interface IDbSession
    {
        IUserInfoDal UserInfoDal{get; }
        IOrderInfoDal OrderInfoDal{get;}
        IActionInfoDal ActionInfoDal { get; }
        IRoleInfoDal RoleInfoDal { get; }
        /// <summary>
        /// 拿到当前EF的上下文对象，然后进行把修改实体进行一个整体提交（简单说该方法就是让上下文提交）
        /// </summary>
        /// <returns></returns>
        int SaveChanges();
    }
}
