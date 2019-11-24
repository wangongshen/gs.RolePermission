using gs.RolePermission.Common;
using gs.RolePermission.IBLL;
using gs.RolePermission.UI.Portal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace gs.RolePermission.UI.Portal.Controllers
{
    //[LoginCheckFilter(IsCheck = false)]
    public class UserLoginController : BaseController
    {
        //通过构造方法指明不去校验用户登录
        public UserLoginController()
        {
            IsCheck = false;
        }

        //导入命名空间，并且通过Spring容器注入UserInfoBll属性,注意是为UserLogin控制器注入UserInfoBll属性。
        public IUserInfoBll UserInfoBll { get; set; }

        // GET: UserLogin
       
        public ActionResult Index()
        {
            if (Request.Cookies["userLoginId"] != null)//表示用户没有登录
            {
                return RedirectToAction("Index", "UserInfo");
            }
            return View();
        }

        /// <summary>
        /// 产生一个随机验证码并返回图片形式
        /// </summary>
        /// <returns></returns>
        public ActionResult ShowVCode()
        {
            Common.ValidateCode validateCode = new ValidateCode();
            string strCode = validateCode.CreateValidateCode(4);

            //把验证码存放到Session，方便后期比较
            Session["Vcode"] = strCode;

            byte[] imgBytes = validateCode.CreateValidateGraphic(strCode);
            return File(imgBytes, @"image/jpeg");
        }


        public ActionResult ProcessLogin()
        {
            //第一步：处理验证码
            //拿到表单找那个的验证码
            string strCode = Request["vCode"];//vCode与前台name相同
            //拿到Session中的验证码
            string sessionCode = Session["Vcode"] as string;//Session["Vcode"]为object，所以要转为string
            //这里存在一个bug，就是strCode、sessionCode均为空,解决通过如下5行代码
            Session["Vcode"] = null;//一拿到Session值就让它为空
            if (string.IsNullOrEmpty(sessionCode))
            {
                return Content("验证码错误！");
            }

            if (string.IsNullOrEmpty(sessionCode))
            {
                return Content("验证码不能为空！");
            }

            if (strCode != sessionCode)
            {
                return Content("验证码错误！");
            }
            //第二步：处理验证用户名及密码
            string name = Request["LoginCode"];
            string pwd = Request["LoginPwd"];
            short delNormal = (short)gs.RolePermission.Model.Enum.DelFlagEnum.Normal;
            var userInfo = UserInfoBll.GetEntities(u => u.Uname == name && u.Pwd == pwd && u.DelFlag == delNormal).FirstOrDefault();
            if (userInfo == null)
            {
                return Content("用户名或密码错误！");
            }
            Session["loginUser"] = userInfo;//此处是写操作，往session里面写数据。此句话保留不注释为了Home控制器还需要通过session来判断用户是否登录。因为虽然过滤器写了验证用户是否登录，但验证是发生在Action执行之前，然而Home控制器下LoadUserMenu()不是Action
            //上面用Session记住当前用户改为下面用Memcache+Cookie来代替
            //立即分配一个标志Guid，把标志作为mm存储数据的key，把用户对象放到mm，把guid写到客户端的cookie
            string userLoginId = Guid.NewGuid().ToString();
            //把用户数据写到mm/HttpRuntimeCache 缓存里面去。如何解决变化点：1。可能写到不同地方（机器）去 2.可能同时写到不同地方去
            Common.Cache.CacheHelper.AddCache(userLoginId, userInfo, DateTime.Now.AddMinutes(20));
            //到Common层封装一个mm，现在Common层新建文件夹Cache,下面先新建一个CacheHelper.cs，封装AddCache、GetCache方法，再新建一个ICacheWriter.cs接口，接口里面也就是写AddCache、GetCache方法结构
            //然后分别添加实现ICacheWriter接口的方法。MemcacheWriter.cs和HttpRuntimeCacheWriter.cs（单机版）

            //往客户端写入cookie,没有写过期时间，默认就为会话级别的cookie，也就是浏览器关闭，cookie消失
            Response.Cookies["userLoginId"].Value = userLoginId;

            //记住用户名、密码。下面7句后加的
            HttpCookie ckUid = new HttpCookie("ckUid", userInfo.Uname);
            HttpCookie ckPwd = new HttpCookie("ckPwd", userInfo.Pwd);
            ckUid.Expires = DateTime.Now.AddDays(3);
            ckPwd.Expires = DateTime.Now.AddDays(3);
            Response.Cookies["userLoginId"].Expires = DateTime.Now.AddDays(3);
            Response.Cookies.Add(ckUid);
            Response.Cookies.Add(ckPwd);
            //第三步：如果正确跳转到首页
            return Content("ok");
        }

    }
}