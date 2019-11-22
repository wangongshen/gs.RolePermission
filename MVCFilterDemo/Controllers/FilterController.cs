using MVCFilterDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCFilterDemo.Controllers
{
    [MyActionFilterAttribute(Name = "过滤器写在类上")]
    public class FilterController : Controller
    {
        // GET: FilterController
        [MyActionFilterAttribute(Name = "过滤器写在方法上")]
        public ActionResult Index()
        {
            Response.Write("<br />Action执行了 <br />");
            return View();
        }
    }
}