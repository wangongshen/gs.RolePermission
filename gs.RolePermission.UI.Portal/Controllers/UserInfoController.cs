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
        short delflagNormal = (short)gs.RolePermission.Model.Enum.DelFlagEnum.Normal;
        short delflagDeleted = (short)gs.RolePermission.Model.Enum.DelFlagEnum.Deleted;
        //IUserInfoBll userInfoBll = new UserInfoBll();
        public IUserInfoBll userInfoBll { get; set; }
        public IRoleInfoBll roleInfoBll { get; set; }
        public IActionInfoBll actionInfoBll { get; set; }
        public IR_UserInfo_ActionInfoBll r_UserInfo_ActionInfoBll { get; set; }
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

        #region 设置用户角色
        public ActionResult SetRole(int id)//这里参数只能是id，为什么？
        {
            ////获取当前要设置的用户
            //int userId = id;
            //UserInfo user = userInfoBll.GetEntities(u => u.Id == id).FirstOrDefault();
            ////ViewBag与ViewData一样都是往前台传数据的一个属性，但是ViewBag更好，是一个动态类型，以后尽量用它
            ////要拿到所有的角色，这就必然要通过RoelInfoBll对象才能拿到，所以还需要把RoelInfoBll属性注入进来本控制器类
            //short delflagNormal = (short)gs.RolePermission.Model.Enum.DelFlagEnum.Normal;
            //ViewBag.AllRoles = roleInfoBll.GetEntities(u => u.DelFlag == delflagNormal).ToList();
            //return View(user);
            //获取当前要设置的用户
            int userId = id;
            UserInfo user = userInfoBll.GetEntities(u => u.Id == id).FirstOrDefault();

            //ViewBag与ViewData一样都是往前台传数据的一个属性，但是ViewBag更好，是一个动态类型，以后尽量用它
            //要拿到所有的角色，这就必然要通过RoelInfoBll对象才能拿到，所以还需要把RoelInfoBll属性注入进来本控制器类

            ViewBag.AllRoles = roleInfoBll.GetEntities(u => u.DelFlag == delflagNormal).ToList();
            //拿到了所有角色之后，前台就好展示，接下来就设置前台

            //用户已关联的角色Id发送到前台。Linq查询
            ViewBag.ExitRoles = (from r in user.RoleInfo select r.Id).ToList();
            return View(user);
        }
        #endregion

        #region 设置特殊权限
        public ActionResult SetAction(int id)
        {
            //获得当前用户
            ViewBag.user = userInfoBll.GetEntities(u => u.Id == id).FirstOrDefault();
            UserInfo userinfo = ViewBag.user;
            // ViewData.Model表示强类型传入视图，在前台视图需要指明model的类型
            ViewData.Model = actionInfoBll.GetEntities(u => u.DelFlag == delflagNormal).ToList();

            //用户已关联的权限Id发送到前台。Linq查询
            ViewBag.ExitAction = (from r in userinfo.R_UserInfo_ActionInfo
                                  where r.HasPermission == true && r.UserInfoId == userinfo.Id && r.DelFlag == delflagNormal
                                  select r.ActionInfoId).ToList();
            ViewBag.DelAction = (from r in userinfo.R_UserInfo_ActionInfo
                                 where r.UserInfoId == userinfo.Id && r.DelFlag == delflagDeleted
                                 select r.ActionInfoId).ToList();
            return View();
        }
        #endregion

        //删除特殊权限
        public ActionResult DeleteUserAction(int UId, int ActionId)
        {
            var rUserAction = r_UserInfo_ActionInfoBll.GetEntities(r => r.ActionInfoId == ActionId && r.UserInfoId == UId).FirstOrDefault();
            if (rUserAction != null)
            {
                //rUserAction.DelFlag = (short)XDZ.RolePermission.Model.Enum.DelFlagEnum.Deleted;//此句不行，不能更新数据库
                //也可以采用调用方法来做,都是逻辑删除
                r_UserInfo_ActionInfoBll.DeleteListByLogical(new List<int>() { rUserAction.Id });
            }
            return Content("ok");
        }

        public ActionResult SetUserAction(int UId, int ActionId, int Value)
        {
            var rUserAction = r_UserInfo_ActionInfoBll.GetEntities(r => r.ActionInfoId == ActionId && r.UserInfoId == UId && r.DelFlag == delflagNormal).FirstOrDefault();
            if (rUserAction != null)
            {
                //根据单击的允许还是拒绝进行修改，HasPermission为boolBean
                rUserAction.HasPermission = (Value == 1 ? true : false);
                r_UserInfo_ActionInfoBll.Update(rUserAction);
            }
            else//不存在就加一条记录
            {
                R_UserInfo_ActionInfo r_UserInfo_ActionInfo = new R_UserInfo_ActionInfo();
                r_UserInfo_ActionInfo.ActionInfoId = ActionId;
                r_UserInfo_ActionInfo.UserInfoId = UId;
                r_UserInfo_ActionInfo.DelFlag = delflagNormal;
                r_UserInfo_ActionInfo.HasPermission = (Value == 1 ? true : false);
                r_UserInfo_ActionInfoBll.Add(r_UserInfo_ActionInfo);
            }
            return Content("ok");
        }
    }
}