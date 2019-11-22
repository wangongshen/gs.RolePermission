using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace gs.RolePermission.UI.Portal.Controllers
{
    public class ActionInfoController : Controller
    {
        public ActionResult Index()
        {
            //int i=0;
            //int b=2/i;
            //return Content(“”); 能把这个运行时错误写入日志

            throw new Exception("抛出的异常测试");
            //ViewData.Model= ActionInfoBll.GetEntities(u => true).AsEnumerable();
            // return View();
        }
    }
}