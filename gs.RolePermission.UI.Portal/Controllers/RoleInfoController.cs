using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using gs.RolePermission.BLL;
using gs.RolePermission.IBLL;
using gs.RolePermission.Model;
using gs.RolePermission.Model.Param;

namespace gs.RolePermission.UI.Portal.Controllers
{
    public class RoleInfoController : Controller
    {
        short delFlagNormal = (short)gs.RolePermission.Model.Enum.DelFlagEnum.Normal;
        public IRoleInfoBll RoleInfoBll { get; set; }
        // GET: RoleInfo
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetAllRoleInfos()
        {
            //jquery easyUI:table:{total:32,rows:[{},{}]}//需要json数据格式
            //jquery easyUI:table:在初始化时自动发送以下两个参数值
            int pageSize = int.Parse(Request["rows"] ?? "10");
            int pageIndex = int.Parse(Request["page"] ?? "1");
            int total = 0;
            //short delFlagNormal = (short)gs.RolePermission.Model.Enum.DelFlagEnum.Normal;
            //拿到过滤条件用户名和备注的值
            string schName = Request["schName"];
            string schRemark = Request["schRemark"];
            var queryParam = new RoleQueryParam()
            {
                PageSize = pageSize,
                PageIndex = pageIndex,
                Total = total,
                SchName = schName,
                SchRemark = schRemark
            };
            var pageData = RoleInfoBll.LoadPageData(queryParam);

            //获取部分列
            var temp = pageData.Select(u => new { ID = u.Id, u.ModifyOn, u.RoleName, u.Remark, u.SubTime });
            //拿到当前页的数据

            //var pageData=UserInfoBll.GetPageEntities(pageSize, pageIndex,out total, u => u.DelFlag == delFlagNormal,u=>u.Id,true).Select(u=>new { ID=u.Id,u.ModifyOn,u.Pwd,u.Remark,u.ShowName,u.SubTime,u.UName});
            var data = new { total = queryParam.Total, rows = temp.ToList() };

            return Json(data, JsonRequestBehavior.AllowGet);

        }
        public ActionResult Add(RoleInfo roleInfo)
        {
            //roleInfo.RoleName = Request["RoleName"];//由于前台的name属性值与后台的属性值相同，具有自动装备功能，不需要赋值即可，当然你赋值也可一定，剩下的Pwd等属性值就不赋值了。
            roleInfo.ModifyOn = DateTime.Now;
            roleInfo.SubTime = DateTime.Now;
            roleInfo.DelFlag = delFlagNormal;
            RoleInfoBll.Add(roleInfo);
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
            //    UserInfoBll.Delete(new UserInfo() { Id = int.Parse(strId) });
            //}
            //2批量删除，只需与数据库发生一次交互
            string[] strIds = ids.Split(',');
            List<int> idList = new List<int>();
            foreach (var strId in strIds)
            {
                idList.Add(int.Parse(strId));
            }
            //UserInfoBll.DeleteList(idList);//真正删除
            RoleInfoBll.DeleteListByLogical(idList);//逻辑删除
            return Content("ok");
        }
        #region 修改
        public ActionResult Edit(int id)
        {
            ViewData.Model = RoleInfoBll.GetEntities(u => u.Id == id).FirstOrDefault();
            return View();
        }
        [HttpPost]
        public ActionResult Edit(RoleInfo roleInfo)
        {
            RoleInfoBll.Update(roleInfo);
            return Content("ok");
        }
        #endregion
    }
}