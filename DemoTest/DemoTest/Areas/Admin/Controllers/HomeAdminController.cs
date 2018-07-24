using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DemoTest.Models.DAO;
using DemoTest.Models.DTO;
namespace DemoTest.Areas.Admin.Controllers
{
    public class HomeAdminController : Controller
    {
        // GET: Admin/HomeAdmin
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetAllSidebar()
        {
            var listsibar = SidebarAdminDAO.Instance.GetListSidebarAdmin();
            return Json(listsibar.ToList(), JsonRequestBehavior.AllowGet);
        }
        
        public JsonResult AddSidebar(string name)
        {
            string result = "Fail";
            if (SidebarAdminDAO.Instance.InsertSidebar(name)) { result = "Success"; return Json(result.ToString(), JsonRequestBehavior.AllowGet)};  
            return Json(result.ToString(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult EditSidebar(int id,string name)
        {
            string result = "Fail";
            if (SidebarAdminDAO.Instance.EditSidebar(id,name)) { result = "Success"; return Json(result.ToString(), JsonRequestBehavior.AllowGet)};
            return Json(result.ToString(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteSidebar(int id)
        {
            string result = "Fail";
            if (SidebarAdminDAO.Instance.DeleteSidebar(id)) { result = "Success"; return Json(result.ToString(), JsonRequestBehavior.AllowGet)};
            return Json(result.ToString(), JsonRequestBehavior.AllowGet);
        }
    }
}