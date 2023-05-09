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
    public class BaoCaoBaoHiemXHController : Controller
    {
        private AccountingSoftwareDbContext db = new AccountingSoftwareDbContext();

        // GET: Administrator/BaoCaoBaoHiemXH
        public ActionResult Index(string thang, string nam)
        {
            var parameters = thang + "/" + nam;
            var BaoCaoBHXHs = db.NhanViens.Select(kh => kh);
            var paramsThamSo = db.ThamSoTinhLuongs.Where(x => x.ThangNam == parameters).FirstOrDefault();
            var listBHXH = new List<BaoCaoBaoHiemXH>();
            var listNhanVien = db.NhanViens.Select(x => x);
            foreach (var item in listNhanVien)
            {
                foreach (var item1 in listBHXH)
                {
                    item1.HoTen = item.HoTen;
                    item1.LuongCoBan = item.LuongCoBan;
                    item1.TLBHXH = paramsThamSo.TLBHXH;
                    item1.TLBHTN = paramsThamSo.TLBHTN;
                    item1.TLBHYT = paramsThamSo.TLBHYT;
                    int total1 = int.Parse(item.LuongCoBan) * int.Parse(paramsThamSo.TLBHXH);
                    item1.MucChiTraTLBHTN = total1.ToString();
                    int total2 = int.Parse(item.LuongCoBan) * int.Parse(paramsThamSo.TLBHTN);
                    item1.MucChiTraTLBHTN = total2.ToString();
                    int total3 = int.Parse(item.LuongCoBan) * int.Parse(paramsThamSo.TLBHYT);
                    item1.MucChiTraTLBHYT = total3.ToString();
                    int total4 = total1 + total2 + total3;
                    item1.TongTien = total4.ToString();
                }
            }
            return View(listBHXH);
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
