using gs.RolePermission.Common;
using gs.RolePermission.Common.Cache;
using gs.RolePermission.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace gs.RolePermission.UI.Portal.Controllers
{
    public class BaseController : Controller
    {
        public bool IsCheck = true;//设置是否需要校验用户是否登录属性
        public UserInfo LoginUser { get; set; }
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            //#region 测试信息
            ////TODO:测试之后删除return
            //return;
            //#endregion
            if (IsCheck)//如果需要校验
            {
                //if (filterContext.HttpContext.Session["loginUser"] == null)
                //{
                //    filterContext.HttpContext.Response.Redirect("UserLogin/Index");
                //}
                //else
                //{
                //    LoginUser = filterContext.HttpContext.Session["loginUser"] as UserInfo;
                //}

                //下面不再从Session中读取用户信息，而改为从缓存里拿到当前登录用户信息
                var userCookies = Request.Cookies["userLoginId"];
                if (userCookies == null)//表示用户没有登录
                {
                    filterContext.HttpContext.Response.Redirect("/UserLogin/Index");
                    return;
                }
                string userGuid = Request.Cookies["userLoginId"].Value;//拿到用户的标志位
                                                                       //然后根据标志位userGuid到缓存里拿到用户信息
                UserInfo userInfo = CacheHelper.GetCache<UserInfo>(userGuid);//object转实体类
                if (userInfo == null)
                {//缓存信息过期了。长时间不操作，超时了
                    filterContext.HttpContext.Response.Redirect("/UserLogin/Index");
                    return;
                }
                LoginUser = userInfo;
                //下面还要把缓存超时时间又重新设置（20分钟）
                CacheHelper.SetCache(userGuid, userInfo, DateTime.Now.AddMinutes(1));//这个实现就是先清掉缓存，然后重新加一个，
            }
        }
    }
}