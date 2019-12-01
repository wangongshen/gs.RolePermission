using gs.RolePermission.BLL;
using gs.RolePermission.IBLL;
using gs.RolePermission.Model;
using gs.RolePermission.Model.Param;
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

        #region 修改
        public ActionResult Edit(int id)
        {
            //往前台传数据
            ViewData.Model = userInfoBll.GetEntities(u => u.Id == id).FirstOrDefault();
            return View();
        }
        #endregion

        [HttpPost]
        public ActionResult Edit(UserInfo userInfo)
        {
            userInfoBll.Update(userInfo);
            return Content("ok");
        }

        public ActionResult Delete(string ids)
        {
            if (string.IsNullOrEmpty(ids))
            {
                return Content("请选中要删除的数据");
            }
            //正常处理
            //1逐个删除，在每个循环里面调用Delete方法都要执行DbSession.SaveChanges() > 0，即与数据库发生交互,而且这是真删除，而且以后每个实体都有删除，那么每个控制器都要写这些方法代码。
            //string[] strIds = ids.Split(',');
            //foreach (var strId in strIds)
            //{
            //    userInfoBll.Delete(new UserInfo() { Id = int.Parse(strId) });
            //}

            string[] strIds = ids.Split(',');
            List<int> idList = new List<int>();
            foreach (var strId in strIds)
            {
                idList.Add(int.Parse(strId));
            }
            //userInfoBll.DeleteList(idList);
            userInfoBll.DeleteListByLogical(idList);//逻辑删除
            return Content("ok");
        }


        public ActionResult Details(int id)
        {
            ViewData.Model = userInfoBll.GetEntities(u => u.Id == id).FirstOrDefault();
            return View();
        }

        public ActionResult GetAllUserInfos()
        {
            //jquery easyUI:table:{total:32,rows:[{},{}]}//需要json数据格式
            //jquery easyUI:table:在初始化时自动发送以下两个参数值
            int pageSize = int.Parse(Request["rows"] ?? "10");
            int pageIndex = int.Parse(Request["page"] ?? "1");
            int total = 0;
            //拿到过滤条件用户名和备注的值
            string schName = Request["schName"];
            string schRemark = Request["schRemark"];
            var queryParam = new UserQueryParam()
            {
                PageSize = pageSize,
                PageIndex = pageIndex,
                Total = total,
                SchName = schName,
                SchRemark = schRemark
            };
            //根据条件查询出数据（并且分好页）
            var pageData = userInfoBll.LoadPageData(queryParam);
            //获取部分列
            var temp = pageData.Select(u => new { ID = u.Id, u.ModifyOn, u.Pwd, u.Remark, u.ShowName, u.SubTime, u.UName });

            var data = new { total = queryParam.Total, rows = temp.ToList() };
            return Json(data, JsonRequestBehavior.AllowGet);

        }

        //添加用户
        public ActionResult Add(UserInfo userInfo)
        {
            userInfo.UName = Request["UName"];//由于前台的name属性值与后台的属性值相同，具有自动装备功能，不需要赋值即可，当然你赋值也可一定，剩下的Pwd等属性值就不赋值了。
            userInfo.ModifyOn = DateTime.Now;
            userInfo.SubTime = DateTime.Now;
            userInfo.DelFlag = (short)gs.RolePermission.Model.Enum.DelFlagEnum.Normal;
            userInfoBll.Add(userInfo);
            return Content("ok");
        }
    }
}