using AccountingSoftware.Models;
using AccountingSoftware.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AccountingSoftware.Areas.Administrator.Controllers
{
    public class AccountController : Controller
    {
        // GET: Administrator/Account
        AccountingSoftwareDbContext db = new AccountingSoftwareDbContext();

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            NguoiDung user = db.NguoiDungs.SingleOrDefault(x => x.TenNguoiDung == username && x.MatKhau == password);
            if (user != null)
            {
                Session["username"] = user.TenNguoiDung;

                Session.Add(ConstaintUser.ADMIN_SESSION, user);
                return RedirectToAction("Index", "Home");
            }
            ViewBag.Error = "Sai tên đăng nhập hoặc mật khẩu!";
            return View();
        }
    }
}