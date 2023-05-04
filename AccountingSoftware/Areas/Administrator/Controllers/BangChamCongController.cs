using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing.Printing;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using AccountingSoftware.Models;
using PagedList;

namespace AccountingSoftware.Areas.Administrator.Controllers
{
    public class BangChamCongController : Controller
    {
        private AccountingSoftwareDbContext db = new AccountingSoftwareDbContext();

        // GET: Administrator/BangChamCong
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var bangChamCongs = db.BangChamCongs.Select(bcc => bcc);
            ViewBag.nhanViens = db.NhanViens.Select(d => d);
            ViewBag.chucvus = db.ChucVus.Select(d => d);
           
            if (!String.IsNullOrEmpty(searchString))
            {
                bangChamCongs = bangChamCongs.Where(dm => dm.NhanVien.HoTen.Contains(searchString));
            }
            return View(bangChamCongs.OrderBy(dm => dm.MaNV).ToPagedList(page, pageSize));
        }

        // GET: Administrator/BangChamCong/Details/5
        [HttpPost]
        public JsonResult Index(int id)
        {
            BangChamCong tk = db.BangChamCongs.Where(a => a.MaCC.Equals(id)).FirstOrDefault();
            return Json(tk, JsonRequestBehavior.AllowGet);
        }

        // GET: Administrator/BangChamCong/Create
        [HttpPost]
        public JsonResult Create(BangChamCong tk)
        {
            try
            {
                var existData = db.BangChamCongs.Where(x => x.MaNV == tk.MaNV).FirstOrDefault();
                if (existData == null)
                {
                    db.BangChamCongs.Add(tk);
                    db.SaveChanges();
                    return Json(new { status = true, message = "Thêm thành công" });
                }
                else
                    return Json(new { status = false, message = "Người dùng này đã tồn tại bảng chấm công" });
            }
            catch (Exception)
            {
                return Json(new { status = false, message = "Đã có lỗi xảy ra" });
            }
        }

        // GET: Administrator/BangChamCong/Edit/5
        [HttpPost]
        public JsonResult Update(BangChamCong tk)
        {
            try
            {
                BangChamCong update = db.BangChamCongs.Where(a => a.MaCC.Equals(tk.MaCC)).FirstOrDefault();
                update.MaNV = tk.MaNV;
                update.DGHQCN= tk.DGHQCN;
                update.SoNgayNghiKhongLuong = tk.SoNgayNghiKhongLuong;
                update.SoNgayLVNgayLe = tk.SoNgayLVNgayLe;
                update.SoNgayLVNgayThuong = tk.SoNgayLVNgayThuong;
                update.SoNgayLVNgayNghiPhep = tk.SoNgayLVNgayNghiPhep;
                update.SoNgayCongThucTe = tk.SoNgayCongThucTe;
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
