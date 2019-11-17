using gs.RolePermission.BLL;
using gs.RolePermission.IBLL;
using gs.RolePermission.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace gs.RolePermission.UI.Portal.Controllers
{
    public class UserInfoController : Controller
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

        public ActionResult Edit(int id) {
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
           ViewData.Model = userInfoBll.GetEntities(u=>u.Id==id).FirstOrDefault();
            return View();
        }

    }
}