using gs.RolePermission.IBLL;
using gs.RolePermission.Model;
using gs.RolePermission.Model.Param;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace gs.RolePermission.UI.Portal.Controllers
{
    public class ActionInfoController : Controller
    {
        short delFlagNormal = (short)gs.RolePermission.Model.Enum.DelFlagEnum.Normal;//直接放在类下，以便公用
        public IRoleInfoBll RoleInfoBll { get; set; }//这个时候要为ActionInfo控制器注入RoleInfoBll属性
        public IActionInfoBll ActionInfoBll { get; set; }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAllActionInfos()
        {
            //jquery easyUI:table:{total:32,rows:[{},{}]}//需要json数据格式
            //jquery easyUI:table:在初始化时自动发送以下两个参数值
            int pageSize = int.Parse(Request["rows"] ?? "10");
            int pageIndex = int.Parse(Request["page"] ?? "1");
            int total = 0;
            //short delFlagNormal = (short)XDZ.RolePermission.Model.Enum.DelFlagEnum.Normal;
            //拿到过滤条件用户名和备注的值
            string schName = Request["schName"];
            string schRemark = Request["schRemark"];
            var queryParam = new ActionQueryParam()
            {
                PageSize = pageSize,
                PageIndex = pageIndex,
                Total = total,
                SchName = schName,
                SchRemark = schRemark
            };
            var pageData = ActionInfoBll.LoadPageData(queryParam);

            //获取部分列
            var temp = pageData.Select(u => new { ID = u.Id, u.ModifyOn, u.ActionName, u.Remark, u.HttpMethod, u.SubTime, u.IsMenu, u.Url, u.Sort, u.MenuIcon });
            var data = new { total = queryParam.Total, rows = temp.ToList() };
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        #region 添加
        public ActionResult Add(ActionInfo actionInfo)
        {
            // actionInfo.ActionName = Request["ActionName"];//无需给属性复制
            actionInfo.ModifyOn = DateTime.Now;
            actionInfo.SubTime = DateTime.Now;
            actionInfo.DelFlag = delFlagNormal;
            ActionInfoBll.Add(actionInfo);
            return Content("ok");
        }
        #endregion

        #region 上传图片处理
        public ActionResult UpLoadImage()
        {
            var file = Request.Files["fileMenuIcon"];//fileMenuIcon与前台保持一致
            string fileName = Path.GetFileName(file.FileName); //获取文件名和扩展名，需要导入System.IO;命名空间
            string path = "/UploadFiles/UploadImgs/" + Guid.NewGuid().ToString() + "-" + fileName;
            file.SaveAs(Request.MapPath(path));
            return Content(path);
        }
        #endregion

        public ActionResult Delete(string ids) {
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
            ActionInfoBll.DeleteListByLogical(idList);//逻辑删除
            return Content("ok");
        }

        #region 修改
        public ActionResult Edit(int id)
        {
            ViewData.Model = ActionInfoBll.GetEntities(u => u.Id == id).FirstOrDefault();
            ActionInfo actionInfo = ViewData.Model as ActionInfo;
            //防止ViewBag.hmList为null，传到前台报错          
            if (actionInfo.HttpMethod != null)
            {
                ViewBag.hmList = actionInfo.HttpMethod.Trim().ToUpper();
            }
            else
            {
                ViewBag.hmList = "POST";//给个默认值，这样ViewBag.hmList就不会为null
            }
            ViewBag.isMenu = actionInfo.IsMenu == true ? true : false;//防止ViewBag.isMenu为null，传到前台报错
            ViewBag.pathMenu = actionInfo.MenuIcon;
            return View();

        }
        [HttpPost]
        public ActionResult Edit(ActionInfo actionInfo)
        {
            ActionInfoBll.Update(actionInfo);
            return Content("ok");
        }

        #endregion
        //设置权限角色
        public ActionResult SetRole(int id)
        {
            //获取当前要设置的权限
            //int actionId = id;
            ActionInfo action = ActionInfoBll.GetEntities(u => u.Id == id).FirstOrDefault();

            //ViewBag与ViewData一样都是往前台传数据的一个属性，但是ViewBag更好，是一个动态类型，以后尽量用它
            //要拿到所有的角色，这就必然要通过RoelInfoBll对象才能拿到，所以还需要把RoelInfoBll属性注入进来本控制器类

            ViewBag.AllRoles = RoleInfoBll.GetEntities(u => u.DelFlag == delFlagNormal).ToList();
            //拿到了所有角色之后，前台就好展示，接下来就设置前台

            //权限已关联的角色Id发送到前台。Linq查询
            ViewBag.ExitRoles = (from r in action.RoleInfo select r.Id).ToList();
            return View(action);
        }
        #region 处理设置用户角色/给用户设置角色
        public ActionResult ProcessSetRole(int UId)
        {
            //1.拿到当前权限ID——在前台把权限ID放在一个隐藏域里面,赋给name属性，然后通过方法参数UId与前台name属性值相同，就可以自动获取,
            //2.拿到前台所有打上勾的用户角色ID
            List<int> setRoleIdList = new List<int>();
            foreach (var key in Request.Form.AllKeys)
            //获取所有post提交过来的参数名称 例如 某个表单提交了 ID NAME SEX 那Allkeys就是 ID NAME SEX 只是键而已 并不是值
            {
                if (key.StartsWith("ckb_"))//说明该控件为checkbox控件
                {
                    int roleId = int.Parse(key.Replace("ckb_", ""));
                    setRoleIdList.Add(roleId);
                }
            }
            ActionInfoBll.SetRole(UId, setRoleIdList);

            return Content("ok");
        }
        #endregion
    }
}