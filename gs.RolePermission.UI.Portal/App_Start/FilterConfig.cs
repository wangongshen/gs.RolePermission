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
            filters.Add(new MyActionFilterAttribute() { Name = "全局的" });
            filters.Add(new MyExceptionFilterAttribute());
        }
    }
}
