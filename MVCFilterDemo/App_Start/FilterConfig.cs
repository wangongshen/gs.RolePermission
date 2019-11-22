using MVCFilterDemo.Models;
using System.Web;
using System.Web.Mvc;

namespace MVCFilterDemo
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new MyActionFilterAttribute() { Name="全局的"});
        }
    }
}
