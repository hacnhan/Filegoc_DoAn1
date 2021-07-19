using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyVanBan.Models;
using Models.DAO;
using QuanLyVanBan.Common;

namespace QuanLyVanBan.Controllers
{
    public class LoginController : Controller
    {
        public UserLogin userSession = new UserLogin();

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        //Đăng nhập
        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new NhanVienDao();
                if (model.UserMail == null)
                {
                    ModelState.AddModelError("", "Vui lòng không bỏ trống Email!");
                }
                else if (model.UserPassword == null)
                {
                    ModelState.AddModelError("", "Vui lòng không bỏ trống Mật khẩu!");
                }
                else
                {
                    var result = dao.Login(model.UserMail, Encryptor.MD5Hash(model.UserPassword));
                    if (result == 1)
                    {
                        var user = dao.GetById(model.UserMail);
                        userSession.UserMail = user.Email;
                        userSession.UserID = user.IDNhanVien;
                        userSession.UserName = user.HoTen;
                        userSession.AuthorID = user.IDPhanQuyen;

                        Session.Add(CommonConstant.USER_SESSION, userSession);
                        return RedirectToAction("Index", "Home");
                    }
                    else if (result == 0)
                    {
                        ModelState.AddModelError("", "Email hoặc mật khẩu không chính xác!");
                    }
                }



            }
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