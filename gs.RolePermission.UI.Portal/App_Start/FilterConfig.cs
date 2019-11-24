using gs.RolePermission.UI.Portal.Models;
using System.Web;
using System.Web.Mvc;

namespace gs.RolePermission.UI.Portal
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //filters.Add(new HandleErrorAttribute());

            //filters.Add(new MyActionFilterAttribute() { Name = "全局的" });
            filters.Add(new MyExceptionFilterAttribute());
            //由基类控制器实现用户是否登录校验，下面就注释掉
            //filters.Add(new LoginCheckFilterAttribute() { IsCheck = true });
        }
    }
}
