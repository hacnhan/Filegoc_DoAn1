using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.EF;
using Models.DAO;
using PagedList;
using QuanLyVanBan.Common;
using System.Net;

namespace QuanLyVanBan.Controllers
{
    public class VanBanDenController : BasicController
    {
        private DbContextVB db = new DbContextVB();
        // GET: VanBanDen
        public ActionResult Index(string searchString1, string searchString2, string searchString3, int page = 1, int pageSize = 5)
        {
            var dao = new VanBanDenDao();
            var session = (QuanLyVanBan.Common.UserLogin)Session[QuanLyVanBan.Common.CommonConstant.USER_SESSION];

            var model = dao.ListAllPaging(searchString1, searchString2, searchString3, page, pageSize, session.UserID);
            if (!string.IsNullOrEmpty(searchString1))
            {
                ViewBag.SearchString1 = searchString1;
            }
            else if (!string.IsNullOrEmpty(searchString2))
            {
                ViewBag.SearchString2 = searchString2;
            }
            else
            {
                ViewBag.SearchString3 = searchString3;
            }
            return View(model);

        }


        //Xoá
        [HttpDelete]
        public ActionResult DeleteRow(string id)
        {
            new VanBanDenDao().Delete(id);

            return RedirectToAction("Index");
        }

        //Chi tiết
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VanBanDen vanBanDen = db.VanBanDens.Find(id);
            if (vanBanDen == null)
            {
                return HttpNotFound();
            }
            return View(vanBanDen);
        }

        //Đăng xuất
        public ActionResult Logout()
        {
            Session[CommonConstant.USER_SESSION] = null;
            return Redirect("/");
        }
    }
}