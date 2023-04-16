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
    public class PhongBanController : Controller
    {
        private AccountingSoftwareDbContext db = new AccountingSoftwareDbContext();

        // GET: Administrator/PhongBan
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            //return View(db.NguoiDungs.ToList());
            var phongbans = db.PhongBans.Select(kh => kh);
            if (!String.IsNullOrEmpty(searchString))
            {
                phongbans = phongbans.Where(dm => dm.TenPhongBan.Contains(searchString));
            }
            return View(phongbans.OrderBy(dm => dm.MaPhongBan).ToPagedList(page, pageSize));
        }

        // GET: Administrator/PhongBan/Details/5
        [HttpPost]
        public JsonResult Index(int id)
        {
            PhongBan pb = db.PhongBans.Where(a => a.MaPhongBan.Equals(id)).FirstOrDefault();
            return Json(pb, JsonRequestBehavior.AllowGet);
        }

        // GET: Administrator/PhongBan/Create
        [HttpPost]
        public JsonResult Create(PhongBan pb)
        {
            try
            {
                var existData = db.PhongBans.Where(x => x.TenPhongBan == pb.TenPhongBan).FirstOrDefault();
                if (existData == null)
                {
                    db.PhongBans.Add(pb);
                    db.SaveChanges();
                    return Json(new { status = true, message = "Thêm thành công" });
                }
                else
                    return Json(new { status = false, message = "Phòng ban này đã tồn tại" });
            }
            catch (Exception)
            {
                return Json(new { status = false, message = "Đã có lỗi xảy ra" });
            }
        }

        // GET: Administrator/PhongBan/Edit/5
        [HttpPost]
        public JsonResult Update(PhongBan pb)
        {
            try
            {
                PhongBan update = db.PhongBans.Where(a => a.MaPhongBan.Equals(pb.MaPhongBan)).FirstOrDefault();
                update.TenPhongBan = pb.TenPhongBan;
                update.SDT = pb.SDT;
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

        // GET: Administrator/PhongBan/Delete/5
        [HttpPost]
        public JsonResult Delete(int id)
        {
            try
            {
                PhongBan pb = db.PhongBans.Where(a => a.MaPhongBan.Equals(id)).FirstOrDefault();
                db.PhongBans.Remove(pb);
                db.SaveChanges();
                return Json(new { status = true, message = "Xoá thành công" });
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
