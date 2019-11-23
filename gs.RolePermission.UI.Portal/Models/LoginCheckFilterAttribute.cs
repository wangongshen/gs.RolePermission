using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace gs.RolePermission.UI.Portal.Models
{
    public class LoginCheckFilterAttribute: ActionFilterAttribute
    {
        public bool IsCheck { get; set; }//设置是否需要校验用户是否登录属性
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            if (IsCheck)//如果需要校验
            {
                if (filterContext.HttpContext.Session["loginUser"] == null)
                {
                    filterContext.HttpContext.Response.Redirect("UserLogin/Index");
                }
            }
        }
    }
}