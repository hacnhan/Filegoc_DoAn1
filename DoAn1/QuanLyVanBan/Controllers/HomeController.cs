using QuanLyVanBan.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyVanBan.Controllers
{
    public class HomeController : BasicController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //Đăng xuất
        public ActionResult Logout()
        {
            Session[CommonConstant.USER_SESSION] = null;
            return Redirect("/");
        }
    }
}