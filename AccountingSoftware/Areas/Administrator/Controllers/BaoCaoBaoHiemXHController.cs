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
            var listModel = new List<BaoCaoBaoHiemXH>();

            var parameters = thang + "/" + nam;
            var paramsThamSo = db.ThamSoTinhLuongs.Where(x => x.ThangNam == parameters).FirstOrDefault();
            if (paramsThamSo == null)
            {
                var newModel = new BaoCaoBaoHiemXH();

                return View(newModel);
            }
            else
            {
                var listNhanVien = db.NhanViens.ToList();
                foreach (var item in listNhanVien)
                {
                    var newModel = new BaoCaoBaoHiemXH();
                    newModel.HoTen = item.HoTen;
                    newModel.LuongCoBan = item.LuongCoBan;
                    newModel.TLBHXH = paramsThamSo.TLBHXH;
                    newModel.TLBHTN = paramsThamSo.TLBHTN;
                    newModel.TLBHYT = paramsThamSo.TLBHYT;
                    int total1 = int.Parse(item.LuongCoBan) * int.Parse(paramsThamSo.TLBHXH);
                    newModel.MucChiTraTLBHXH = total1.ToString();
                    int total2 = int.Parse(item.LuongCoBan) * int.Parse(paramsThamSo.TLBHTN);
                    newModel.MucChiTraTLBHTN = total2.ToString();
                    int total3 = int.Parse(item.LuongCoBan) * int.Parse(paramsThamSo.TLBHYT);
                    newModel.MucChiTraTLBHYT = total3.ToString();
                    int total4 = total1 + total2 + total3;
                    newModel.TongTien = total4.ToString();
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
