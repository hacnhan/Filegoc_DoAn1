using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Models.EF;
using Models.DAO;
using PagedList;
using QuanLyVanBan.Common;

namespace QuanLyVanBan.Controllers
{
    public class NhanVienController : BasicController
    {
        private DbContextVB db = new DbContextVB();

        // GET: NhanVien
        public ActionResult Index(string searchString1, string searchString2, int page = 1, int pageSize = 5)
        {
            var dao = new NhanVienDao();
           
            var model = dao.ListAllPaging(searchString1, searchString2, page, pageSize);
            if (!string.IsNullOrEmpty(searchString1))
            {
                ViewBag.SearchString1 = searchString1;
            }
            else
            {
                ViewBag.SearchString2 = searchString2;
            }
            return View(model);
        }

        // GET: NhanVien/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanVien nhanVien = db.NhanViens.Find(id);
            if (nhanVien == null)
            {
                return HttpNotFound();
            }
            return View(nhanVien);
        }

        // GET: NhanVien/Create
        public ActionResult Create()
        {
            ViewBag.IDPhanQuyen = new SelectList(db.PhanQuyens, "IDPhanQuyen", "TenQuyen");
            ViewBag.IDPhongBan = new SelectList(db.PhongBanKhoas, "IDPhongBan", "TenPhongBan");
            return View();
        }

        // POST: NhanVien/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDNhanVien,IDPhongBan,IDPhanQuyen,MatKhau,HoTen,Email,SDT,DiaChi,ChucVu,GioiTinh")] NhanVien nhanVien)
        {
            if (ModelState.IsValid)
            {
                nhanVien.IDNhanVien = "NV" + (db.NhanViens.Count() + 1).ToString();

                var encryptedMd5Pas = Encryptor.MD5Hash(nhanVien.MatKhau);
                nhanVien.MatKhau = encryptedMd5Pas;

                db.NhanViens.Add(nhanVien);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDPhanQuyen = new SelectList(db.PhanQuyens, "IDPhanQuyen", "TenQuyen", nhanVien.IDPhanQuyen);
            ViewBag.IDPhongBan = new SelectList(db.PhongBanKhoas, "IDPhongBan", "TenPhongBan", nhanVien.IDPhongBan);
            return View(nhanVien);
        }

        // GET: NhanVien/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanVien nhanVien = db.NhanViens.Find(id);
            if (nhanVien == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDPhanQuyen = new SelectList(db.PhanQuyens, "IDPhanQuyen", "TenQuyen", nhanVien.IDPhanQuyen);
            ViewBag.IDPhongBan = new SelectList(db.PhongBanKhoas, "IDPhongBan", "TenPhongBan", nhanVien.IDPhongBan);
            return View(nhanVien);
        }

        // POST: NhanVien/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDNhanVien,IDPhongBan,IDPhanQuyen,MatKhau,HoTen,Email,SDT,DiaChi,ChucVu,GioiTinh")] NhanVien nhanVien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nhanVien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDPhanQuyen = new SelectList(db.PhanQuyens, "IDPhanQuyen", "TenQuyen", nhanVien.IDPhanQuyen);
            ViewBag.IDPhongBan = new SelectList(db.PhongBanKhoas, "IDPhongBan", "TenPhongBan", nhanVien.IDPhongBan);
            return View(nhanVien);
        }

        // GET: NhanVien/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanVien nhanVien = db.NhanViens.Find(id);
            if (nhanVien == null)
            {
                return HttpNotFound();
            }
            return View(nhanVien);
        }

        // POST: NhanVien/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            NhanVien nhanVien = db.NhanViens.Find(id);
            db.NhanViens.Remove(nhanVien);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        //Đăng xuất
        public ActionResult Logout()
        {
            Session[CommonConstant.USER_SESSION] = null;
            return Redirect("/");
        }

        [HttpDelete]
        public ActionResult DeleteRow(string id)
        {
            new NhanVienDao().Delete(id);

            return RedirectToAction("Index");
        }
    }
}
