using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AccountingSoftware.Models;
using PagedList;

namespace AccountingSoftware.Areas.Administrator.Controllers
{
    public class NguoiDungController : Controller
    {
        private AccountingSoftwareDbContext db = new AccountingSoftwareDbContext();

        // GET: Administrator/NguoiDung
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            //return View(db.NguoiDungs.ToList());
            var khachhangs = db.NguoiDungs.Select(kh => kh);
            if (!String.IsNullOrEmpty(searchString))
            {
                khachhangs = khachhangs.Where(dm => dm.TenNguoiDung.Contains(searchString));
            }
            return View(khachhangs.OrderBy(dm => dm.MaNguoiDung).ToPagedList(page, pageSize));
        }

        // GET: Administrator/NguoiDung/Details/5
        [HttpPost]
        public JsonResult Index(int id)
        {
            NguoiDung tk = db.NguoiDungs.Where(a => a.MaNguoiDung.Equals(id)).FirstOrDefault();
            return Json(tk, JsonRequestBehavior.AllowGet);
        }

        // GET: Administrator/NguoiDung/Create
        [HttpPost]
        public JsonResult Create(NguoiDung tk)
        {
            try
            {
                var existData = db.NguoiDungs.Where(x => x.TenNguoiDung == tk.TenNguoiDung).FirstOrDefault();
                if (existData == null)
                {
                    db.NguoiDungs.Add(tk);
                    db.SaveChanges();
                    return Json(new { status = true, message = "Thêm thành công" });
                }
                else
                    return Json(new { status = false, message = "Người dùng này đã tồn tại tài khoản" });
            }
            catch (Exception)
            {
                return Json(new { status = false, message = "Đã có lỗi xảy ra" });
            }
        }

        // GET: Administrator/NguoiDung/Edit/5
        [HttpPost]
        public JsonResult Update(NguoiDung tk)
        {
            try
            {
                NguoiDung update = db.NguoiDungs.Where(a => a.MaNguoiDung.Equals(tk.MaNguoiDung)).FirstOrDefault();
                update.TenNguoiDung = tk.TenNguoiDung;
                update.MatKhau = tk.MatKhau;
                update.QuanTri = tk.QuanTri;
                db.Entry(update).State = EntityState.Modified;
                db.SaveChanges();
                return Json(new { status = true, message = "Sửa thông tin thành công" });
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return Json(new { status = false, message = "Đã có lỗi xảy ra" });
            }
        }

        // GET: Administrator/NguoiDung/Delete/5
        [HttpPost]
        public JsonResult Delete(int id)
        {
            try
            {
                NguoiDung tk = db.NguoiDungs.Where(a => a.MaNguoiDung.Equals(id)).FirstOrDefault();
                db.NguoiDungs.Remove(tk);
                db.SaveChanges();
                return Json(new { status = true });
            }
            catch (Exception)
            {
                return Json(new { status = false });
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
