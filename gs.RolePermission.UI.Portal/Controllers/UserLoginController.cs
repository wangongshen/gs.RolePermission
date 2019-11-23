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
    [LoginCheckFilter(IsCheck = false)]
    public class UserLoginController : Controller
    {
        //导入命名空间，并且通过Spring容器注入UserInfoBll属性,注意是为UserLogin控制器注入UserInfoBll属性。
        public IUserInfoBll UserInfoBll { get; set; }

        // GET: UserLogin
       
        public ActionResult Index()
        {
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
            Session["loginUser"] = userInfo;
            //第三步：如果正确跳转到首页
            return Content("ok");
        }

    }
}