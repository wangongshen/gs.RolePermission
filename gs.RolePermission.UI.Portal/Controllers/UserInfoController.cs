using gs.RolePermission.BLL;
using gs.RolePermission.IBLL;
using gs.RolePermission.Model;
using gs.RolePermission.UI.Portal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace gs.RolePermission.UI.Portal.Controllers
{
    //[MyActionFilterAttribute(Name ="写在类上的过滤器")]
    public class UserInfoController : BaseController
    {

        //IUserInfoBll userInfoBll = new UserInfoBll();
        public IUserInfoBll userInfoBll { get; set; }
        // GET: UserInfo
        public ActionResult Index()
        {
            ViewData.Model = userInfoBll.GetEntities(u => true);
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(UserInfo userInfo)
        {
            if (ModelState.IsValid == true)
            {
                userInfoBll.Add(userInfo);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            ViewData.Model = userInfoBll.GetEntities(u => u.Id == id).FirstOrDefault();
            return View();
        }

        [HttpPost]
        public ActionResult Edit(UserInfo userInfo)
        {
            userInfoBll.Update(userInfo);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            userInfoBll.Delete(id);
            return RedirectToAction("Index");
        }


        public ActionResult Details(int id)
        {
            ViewData.Model = userInfoBll.GetEntities(u => u.Id == id).FirstOrDefault();
            return View();
        }

        public ActionResult GetAllUserInfos()
        {
            //jquery easyUI:table:{total:88,rows:[{},{}]}//需要json数据格式
            //jquery easyUI:table:在初始化时自动发送以下两个参数值
            int pageSize = int.Parse(Request["rows"] ?? "10");
            int pageIndex = int.Parse(Request["page"] ?? "1");
            int total = 0;
            //拿到当前页的数据
            short delFlagNormal = (short)gs.RolePermission.Model.Enum.DelFlagEnum.Normal;
            var pageData = userInfoBll.GetPageEntities(pageSize, pageIndex, out total, u => u.DelFlag == delFlagNormal, u => u.Id, true).Select(u => new { ID = u.Id, u.ModifyOn, u.Pwd, u.Remark, u.ShowName, u.SubTime, u.UName });//解决循环引用问题
            //接下来需要把数据格式转换为table:{total:88,rows:[{},{}]}格式传给前台。怎么转呢？直接通过一个匿名类即可
            var data = new { total = total, rows = pageData.ToList() };
            //下面转为Json字符串格式，并输出至前台。允许是Get请求
            return Json(data, JsonRequestBehavior.AllowGet);

        }
    }
}