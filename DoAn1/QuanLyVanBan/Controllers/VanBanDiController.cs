using Models.EF;
using Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using QuanLyVanBan.Common;
using System.Net;

namespace QuanLyVanBan.Controllers
{
    public class VanBanDiController : BasicController
    {
        private DbContextVB db = new DbContextVB();
        // GET: VanBanDi
        public ActionResult Index(string searchString1, string searchString2, string searchString3, int page = 1, int pageSize = 5)
        {
            var dao = new VanBanDiDao();
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

        //Gửi
        public ActionResult Send()
        {
            ViewBag.IDFileDinhKem = new SelectList(db.FileDinhKems, "IDFileDinhKem", "TenFile");
            ViewBag.IDLVB = new SelectList(db.LoaiVanBans, "IDLVB", "TenLVB");
            ViewBag.IDDoKhan = new SelectList(db.MucDoKhans, "IDDoKhan", "TenMucDoKhan");
            ViewBag.IDNhanVien = new SelectList(db.NhanViens, "IDNhanVien", "HoTen");
            ViewBag.IDPhongBan = new SelectList(db.PhongBanKhoas, "IDPhongBan", "TenPhongBan");

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Send([Bind(Include = "IDVanBanDi,IDLVB,IDDoKhan,IDNhanVien,IDFileDinhKem,KyHieuVanBanDi,NgayBanHanh,NgayGui,NgayHieuLuc,NoiNhan,NoiDung,TieuDe,NguoiKyTen,HanXuLy,TinhTrang")] VanBanDi vanBanDi)
        {
            var dao = new VanBanDenDao();
            var session = (QuanLyVanBan.Common.UserLogin)Session[QuanLyVanBan.Common.CommonConstant.USER_SESSION];
            if (ModelState.IsValid)
            {
                vanBanDi.NgayGui = DateTime.Now;
                dao.ThemVanBanDen(vanBanDi);
                vanBanDi.IDVanBanDi = (db.VanBanDis.Count() + 1).ToString();
                vanBanDi.IDNguoiGui = session.UserID;
                db.VanBanDis.Add(vanBanDi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDFileDinhKem = new SelectList(db.FileDinhKems, "IDFileDinhKem", "TenFile", vanBanDi.IDFileDinhKem);
            ViewBag.IDLVB = new SelectList(db.LoaiVanBans, "IDLVB", "TenLVB", vanBanDi.IDLVB);
            ViewBag.IDDoKhan = new SelectList(db.MucDoKhans, "IDDoKhan", "TenMucDoKhan", vanBanDi.IDDoKhan);
            ViewBag.IDNhanVien = new SelectList(db.NhanViens, "IDNhanVien", "IDPhongBan", vanBanDi.IDNhanVien);
            return View(vanBanDi);
        }


        //Chuyển tiếp
        public ActionResult Resend()
        {
            ViewBag.IDNhanVien = new SelectList(db.NhanViens, "IDNhanVien", "HoTen");
            ViewBag.IDPhongBan = new SelectList(db.PhongBanKhoas, "IDPhongBan", "TenPhongBan");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Resend([Bind(Include = "IDVanBanDi,IDLVB,IDDoKhan,IDNhanVien,IDFileDinhKem,KyHieuVanBanDi,NgayBanHanh,NgayGui,NgayHieuLuc,NoiNhan,NoiDung,TieuDe,NguoiKyTen,HanXuLy,TinhTrang")] VanBanDi vanBanDi, string id, string idUser)
        {
            
            if (ModelState.IsValid)
            {
                VanBanDen vanBanDen = db.VanBanDens.Find(id);
                var dao = new VanBanDiDao();
                dao.ChuyenTiepVanBanDen(vanBanDen, vanBanDi.IDNhanVien);
                return RedirectToAction("Index", "VanBanDen");
            }
            ViewBag.IDNhanVien = new SelectList(db.NhanViens, "IDNhanVien", "HoTen");
            ViewBag.IDPhongBan = new SelectList(db.PhongBanKhoas, "IDPhongBan", "TenPhongBan");

            return View("Index");
        }

        //Đăng xuất
        public ActionResult Logout()
        {
            Session[CommonConstant.USER_SESSION] = null;
            return Redirect("/");
        }
    }
}