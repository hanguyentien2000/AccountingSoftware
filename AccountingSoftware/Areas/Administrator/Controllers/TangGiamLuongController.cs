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
    public class TangGiamLuongController : Controller
    {
        private AccountingSoftwareDbContext db = new AccountingSoftwareDbContext();

        // GET: Administrator/TangGiamLuong
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            //return View(db.TangGiamLuongs.ToList());
            var khachhangs = db.TangGiamLuongs.Select(kh => kh);
            ViewBag.nhanviens = db.NhanViens.Select(x => x);
            if (!String.IsNullOrEmpty(searchString))
            {
                khachhangs = khachhangs.Where(dm => dm.NgayThang.Contains(searchString));
            }
            return View(khachhangs.OrderBy(dm => dm.MaTangGiamLuong).ToPagedList(page, pageSize));
        }

        // GET: Administrator/TangGiamLuong/Details/5
        [HttpPost]
        public JsonResult Index(int id)
        {
            TangGiamLuong tk = db.TangGiamLuongs.Where(a => a.MaTangGiamLuong.Equals(id)).FirstOrDefault();
            return Json(tk, JsonRequestBehavior.AllowGet);
        }

        // GET: Administrator/TangGiamLuong/Create
        [HttpPost]
        public JsonResult Create(TangGiamLuong tk)
        {
            try
            {
                var existData = db.TangGiamLuongs.Where(x => x.MaNV == tk.MaNV).FirstOrDefault();
                if (existData == null)
                {
                    db.TangGiamLuongs.Add(tk);
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

        // GET: Administrator/TangGiamLuong/Edit/5
        [HttpPost]
        public JsonResult Update(TangGiamLuong tk)
        {
            try
            {
                TangGiamLuong update = db.TangGiamLuongs.Where(a => a.MaTangGiamLuong.Equals(tk.MaTangGiamLuong)).FirstOrDefault();
                update.NgayThang = tk.NgayThang;
                update.ThongTin = tk.ThongTin;
                update.TaiKhoanChinh = tk.TaiKhoanChinh;
                update.TaiKhoanNo = tk.TaiKhoanNo;
                update.SoTien = tk.SoTien;
                update.MaNV = tk.MaNV;
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

        // GET: Administrator/TangGiamLuong/Delete/5
        [HttpPost]
        public JsonResult Delete(int id)
        {
            try
            {
                TangGiamLuong tk = db.TangGiamLuongs.Where(a => a.MaTangGiamLuong.Equals(id)).FirstOrDefault();
                db.TangGiamLuongs.Remove(tk);
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
