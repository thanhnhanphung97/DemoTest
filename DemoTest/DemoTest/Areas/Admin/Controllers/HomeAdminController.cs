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
        [HttpGet]
        public ActionResult Index()
        {
            Check.Out();
            Session["currentPage"] = Request.Url.AbsoluteUri;
            Session["id"] = "";
            ViewBag.Text = Session["loginSession"];
            return View();
        }

        public JsonResult GetAllSidebar()
        {
            var listsibar = SidebarAdminDAO.Instance.GetListSidebarAdmin();
            return Json(listsibar.ToList(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult AddSidebar(string Name,string Img)
        {
            string result = "Fail";
            if (SidebarAdminDAO.Instance.InsertSidebar(Name, Img)) { result = "Success"; return Json(result.ToString(), JsonRequestBehavior.AllowGet); };  
            return Json(result.ToString(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult EditSidebar(int Id,string Name, string Img)
        {
            string result = "Fail";
            if (SidebarAdminDAO.Instance.EditSidebar(Id, Name, Img)) { result = "Success"; return Json(result.ToString(), JsonRequestBehavior.AllowGet); };
            return Json(result.ToString(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult DeleteSidebar(int Id)
        {
            string result = "Fail";
            if (SidebarAdminDAO.Instance.DeleteSidebar(Id)) { result = "Success"; return Json(result.ToString(), JsonRequestBehavior.AllowGet); };
            return Json(result.ToString(), JsonRequestBehavior.AllowGet);
        }
        
    }
}