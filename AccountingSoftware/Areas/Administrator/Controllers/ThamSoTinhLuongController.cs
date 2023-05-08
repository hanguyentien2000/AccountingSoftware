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
    public class ThamSoTinhLuongController : Controller
    {
        private AccountingSoftwareDbContext db = new AccountingSoftwareDbContext();

        // GET: Administrator/ThamSoTinhLuong
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var khachhangs = db.ThamSoTinhLuongs.Select(kh => kh);
            ViewBag.nhanViens = db.NhanViens.Select(x => x);
            if (!String.IsNullOrEmpty(searchString))
            {
                khachhangs = khachhangs.Where(dm => dm.ThangNam.Contains(searchString));
            }
            return View(khachhangs.OrderBy(dm => dm.MaThamSo).ToPagedList(page, pageSize));
        }

        // GET: Administrator/ThamSoTinhLuong/Details/5
        [HttpPost]
        public JsonResult Index(int id)
        {
            ThamSoTinhLuong tk = db.ThamSoTinhLuongs.Where(a => a.MaThamSo.Equals(id)).FirstOrDefault();
            return Json(tk, JsonRequestBehavior.AllowGet);
        }

        // POST: Administrator/ThamSoTinhLuong/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public JsonResult Create(ThamSoTinhLuong tk)
        {
            try
            {
                var existData = db.ThamSoTinhLuongs.Where(x => x.ThangNam == tk.ThangNam).FirstOrDefault();
                if (existData == null)
                {
                    db.ThamSoTinhLuongs.Add(tk);
                    db.SaveChanges();
                    return Json(new { status = true, message = "Thêm thành công" });
                }
                else
                    return Json(new { status = false, message = "Người dùng này đã tồn tại tài khoản" });
            }
            catch (Exception ex)
            {
                return Json(new { status = false, message = ex.Message });
            }
        }

        // GET: Administrator/ThamSoTinhLuong/Edit/5
        [HttpPost]
        public JsonResult Update(ThamSoTinhLuong tk)
        {
            try
            {
                ThamSoTinhLuong update = db.ThamSoTinhLuongs.Where(a => a.MaThamSo.Equals(tk.MaThamSo)).FirstOrDefault();
                update.CongLuong = tk.CongLuong;
                update.GiamTruBanThan = tk.GiamTruBanThan;
                update.GiamTruNPT = tk.GiamTruNPT;
                update.GioCongNgay = tk.GioCongNgay;
                update.HsNgayLe = tk.HsNgayLe;
                update.HsNgayThuong = tk.HsNgayThuong;
                update.ThangNam = tk.ThangNam;
                update.TLBHTN = tk.TLBHTN;
                update.TLBHXH = tk.TLBHXH;
                update.TLBHYT = tk.TLBHYT;
                update.TLKPCD = tk.TLKPCD;
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
        [HttpPost]
        public JsonResult Delete(int id)
        {
            try
            {
                ThamSoTinhLuong tk = db.ThamSoTinhLuongs.Where(a => a.MaThamSo.Equals(id)).FirstOrDefault();
                db.ThamSoTinhLuongs.Remove(tk);
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
