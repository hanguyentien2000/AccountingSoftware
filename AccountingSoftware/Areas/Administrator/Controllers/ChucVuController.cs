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
    public class ChucVuController : Controller
    {
        private AccountingSoftwareDbContext db = new AccountingSoftwareDbContext();

        // GET: Administrator/ChucVu
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            //return View(db.NguoiDungs.ToList());
            var chucvus = db.ChucVus.Select(kh => kh);
            if (!String.IsNullOrEmpty(searchString))
            {
                chucvus = chucvus.Where(dm => dm.TenChucVu.Contains(searchString));
            }
            return View(chucvus.OrderBy(dm => dm.MaChucVu).ToPagedList(page, pageSize));
        }

        // GET: Administrator/ChucVu/Details/5
        [HttpPost]
        public JsonResult Index(int id)
        {
            ChucVu cv = db.ChucVus.Where(a => a.MaChucVu.Equals(id)).FirstOrDefault();
            return Json(cv, JsonRequestBehavior.AllowGet);
        }
        // GET: Administrator/ChucVu/Create
        [HttpPost]
        public JsonResult Create(ChucVu cv)
        {
            try
            {
                var existData = db.ChucVus.Where(x => x.TenChucVu == cv.TenChucVu).FirstOrDefault();
                if (existData == null)
                {
                    db.ChucVus.Add(cv);
                    db.SaveChanges();
                    return Json(new { status = true, message = "Thêm thành công" });
                }
                else
                    return Json(new { status = false, message = "Chức vụ này đã tồn tại" });
            }
            catch (Exception)
            {
                return Json(new { status = false, message = "Đã có lỗi xảy ra" });
            }
        }

        // GET: Administrator/ChucVu/Edit/5
        [HttpPost]
        public JsonResult Update(ChucVu cv)
        {
            try
            {
                ChucVu update = db.ChucVus.Where(a => a.MaChucVu.Equals(cv.MaChucVu)).FirstOrDefault();
                update.TenChucVu = cv.TenChucVu;
                update.HeSoPhuCapCV = cv.HeSoPhuCapCV;
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

        // GET: Administrator/ChucVu/Delete/5
        [HttpPost]
        public JsonResult Delete(int id)
        {
            try
            {
                ChucVu cv = db.ChucVus.Where(a => a.MaChucVu.Equals(id)).FirstOrDefault();
                db.ChucVus.Remove(cv);
                db.SaveChanges();
                return Json(new { status = true, message = "Xoá thành công" });
            }
            catch (Exception)
            {
                return Json(new { status = false, message = "Đã có lỗi xảy ra" });
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
