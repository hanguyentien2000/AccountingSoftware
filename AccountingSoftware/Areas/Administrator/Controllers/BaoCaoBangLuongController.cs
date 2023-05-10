using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AccountingSoftware.Models;

namespace AccountingSoftware.Areas.Administrator.Controllers
{
    public class BaoCaoLuongController : Controller
    {
        private AccountingSoftwareDbContext db = new AccountingSoftwareDbContext();

        // GET: Administrator/BaoCaoBaoHiemXH
        public ActionResult Index(string thang, string nam)
        {
            var listModel = new List<BaoCaoBangLuong>();

            var parameters = thang + "/" + nam;
            var paramsThamSo = db.ThamSoTinhLuongs.Where(x => x.ThangNam == parameters).FirstOrDefault();
            if (paramsThamSo == null)
            {
                var newModel = new BaoCaoBangLuong();

                return View(newModel);
            }
            else
            {
                var listNhanVien = db.NhanViens.Include(s => s.BangChamCongs).ToList();
                foreach (var item in listNhanVien)
                {
                    var soCong = db.BangChamCongs.Where(x => x.MaNV == item.MaNV).FirstOrDefault();
                    var newModel = new BaoCaoBangLuong();
                    newModel.HoTen = item.HoTen;
                    newModel.LuongThoaThuan = item.LuongThoaThuan;
                    newModel.LuongCoBan = item.LuongCoBan;
                    newModel.CongLuong = paramsThamSo.CongLuong;
                    newModel.SoNgayCongThucTe = soCong.SoNgayCongThucTe;
                    int total1 = int.Parse(item.LuongCoBan) * int.Parse(paramsThamSo.TLBHXH);
                    newModel.BHXH = total1.ToString();
                    int total2 = int.Parse(item.LuongCoBan) * int.Parse(paramsThamSo.TLBHTN);
                    newModel.BHTN = total2.ToString();
                    int total3 = int.Parse(item.LuongCoBan) * int.Parse(paramsThamSo.TLBHYT);
                    newModel.BHYT = total3.ToString();
                    //int total4 = 
                    //newModel.TongTien = total4.ToString();
                    listModel.Add(newModel);
                }
                ViewBag.ListBhxh = listModel;
                return View(ViewBag.ListBhxh);
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
