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
    public class NhanVienController : Controller
    {
        private AccountingSoftwareDbContext db = new AccountingSoftwareDbContext();

        // GET: Administrator/NhanVien
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            ViewBag.searchString = searchString;
            ViewBag.chucvus = db.ChucVus.Select(d => d);
            ViewBag.phongbans = db.PhongBans.Select(d => d);
            var staffs = db.NhanViens.Select(kh => kh);
            if (!String.IsNullOrEmpty(searchString))
            {
                staffs = staffs.Where(x => x.HoTen.Contains(searchString));
            }
            return View(staffs.OrderBy(x => x.MaNV).ToPagedList(page, pageSize));
        }
       
        // GET: Administrator/NhanVien/Details/5
        [HttpPost]
        public JsonResult Index(int id)
        {
            NhanVien nv = db.NhanViens.Where(a => a.MaNV.Equals(id)).FirstOrDefault();
            return Json(nv, JsonRequestBehavior.AllowGet);
        }

        // GET: Administrator/NhanVien/Create
        [HttpPost]
        public JsonResult Create(NhanVien nv)
        {
            try
            {
                NhanVien existData = db.NhanViens.FirstOrDefault(x => x.HoTen == nv.HoTen);
                if (existData != null)
                {
                    return Json(new { status = false, message = "Đã tồn tại tên đăng nhập này" });
                }
                else
                {
                    db.NhanViens.Add(nv);
                    db.SaveChanges();
                    return Json(new { status = true, message = "Thêm thành công" });
                }
            }
            catch (Exception)
            {
                return Json(new { status = false, message = "Đã có lỗi xảy ra" });
            }
        }

        // GET: Administrator/NhanVien/Edit/5
        [HttpPost]
        public JsonResult Update(NhanVien nv)
        {
            try
            {
                NhanVien update = db.NhanViens.Where(a => a.MaNV.Equals(nv.MaNV)).FirstOrDefault();
                update.HoTen = nv.HoTen;
                update.MaSoThue = nv.MaSoThue;
                update.NgaySinh = nv.NgaySinh;
                update.GioiTinh = nv.GioiTinh;
                update.QueQuan = nv.QueQuan;
                update.SoNguoiPhuThuoc = nv.SoNguoiPhuThuoc;
                update.DiaChi = nv.DiaChi;
                update.LuongCoBan = nv.LuongCoBan;
                update.LuongThoaThuan = nv.LuongThoaThuan;
                update.NgayVaoLam = nv.NgayVaoLam;
                update.MaChucVu = nv.MaChucVu;
                update.MaPhongBan = nv.MaPhongBan;
                update.MaSoThue = nv.MaSoThue;
                db.Entry(update).State = EntityState.Modified;
                db.SaveChanges();
                return Json(new { status = true, message = "Sửa thông tin thành công" });
            }
            catch (Exception)
            {
                return Json(new { status = false, message = "Đã có lỗi xảy ra" });
            }
        }

        // GET: Administrator/NhanVien/Delete/5
        [HttpPost]
        public JsonResult Delete(int id)
        {
            try
            {
                NhanVien nv = db.NhanViens.Where(a => a.MaNV.Equals(id)).FirstOrDefault();
                db.NhanViens.Remove(nv);
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
