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
    public class ThueTNCNController : Controller
    {
        private AccountingSoftwareDbContext db = new AccountingSoftwareDbContext();

        // GET: Administrator/ThueTNCN
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var thueTNCNs = db.ThueTNCNs.Select(kh => kh);
            if (!String.IsNullOrEmpty(searchString))
            {
                thueTNCNs = thueTNCNs.Where(dm => dm.Tu.Contains(searchString));
            }
            return View(thueTNCNs.OrderBy(dm => dm.MaThueTNCN).ToPagedList(page, pageSize));
        }

        // GET: Administrator/ThueTNCN/Details/5
        [HttpPost]
        public JsonResult Index(int id)
        {
            ThueTNCN tk = db.ThueTNCNs.Where(a => a.MaThueTNCN.Equals(id)).FirstOrDefault();
            return Json(tk, JsonRequestBehavior.AllowGet);
        }

        // GET: Administrator/ThueTNCN/Create
        [HttpPost]
        public JsonResult Create(ThueTNCN tk)
        {
            try
            {
                var existData = db.ThueTNCNs.Where(x => x.BacThue == tk.BacThue).FirstOrDefault();
                if (existData == null)
                {
                    db.ThueTNCNs.Add(tk);
                    db.SaveChanges();
                    return Json(new { status = true, message = "Thêm thành công" });
                }
                else
                    return Json(new { status = false, message = "Bậc thuế này đã tồn tại" });
            }
            catch (Exception)
            {
                return Json(new { status = false, message = "Đã có lỗi xảy ra" });
            }
        }

        // GET: Administrator/ThueTNCN/Edit/5
        [HttpPost]
        public JsonResult Update(ThueTNCN tk)
        {
            try
            {
                ThueTNCN update = db.ThueTNCNs.Where(a => a.MaThueTNCN.Equals(tk.MaThueTNCN)).FirstOrDefault();
                update.Tu = tk.Tu;
                update.Den = tk.Den;
                update.BacThue = tk.BacThue;
                update.ThueSuat = tk.ThueSuat;
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

        // GET: Administrator/ThueTNCN/Delete/5
        [HttpPost]
        public JsonResult Delete(int id)
        {
            try
            {
                ThueTNCN tk = db.ThueTNCNs.Where(a => a.MaThueTNCN.Equals(id)).FirstOrDefault();
                db.ThueTNCNs.Remove(tk);
                db.SaveChanges();
                return Json(new { status = true, message = "Xoá thành công" });
            }
            catch (Exception)
            {
                return Json(new { status = false });
            }
        }

        // POST: Administrator/ThueTNCN/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ThueTNCN thueTNCN = db.ThueTNCNs.Find(id);
            db.ThueTNCNs.Remove(thueTNCN);
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
    }
}
