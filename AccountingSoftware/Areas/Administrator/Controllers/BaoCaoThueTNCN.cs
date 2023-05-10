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
    public class BaoCaoThueTNCNController : Controller
    {
        private AccountingSoftwareDbContext db = new AccountingSoftwareDbContext();

        // GET: Administrator/BaoCaoBaoHiemXH
        public ActionResult Index(string thang, string nam)
        {
            var listModel = new List<BaoCaoThueTNCN>();
            var listTNCN = db.ThueTNCNs.ToList();
            var parameters = thang + "/" + nam;
            var paramsThamSo = db.ThamSoTinhLuongs.Where(x => x.ThangNam == parameters).FirstOrDefault();
            if (paramsThamSo == null)
            {
                var newModel = new BaoCaoThueTNCN();

                return View(newModel);
            }
            else
            {
                var listNhanVien = db.NhanViens.ToList();
                foreach (var item in listNhanVien)
                {
                    var newModel = new BaoCaoThueTNCN();
                    newModel.HoTen = item.HoTen;
                    newModel.MaSoThue = item.MaSoThue;
                    newModel.LuongThoaThuan = item.LuongThoaThuan;
                    newModel.SoNPT = item.SoNguoiPhuThuoc;
                    newModel.GiamTruNguoiNop = paramsThamSo.TLBHTN;
                    int total1 = int.Parse(item.SoNguoiPhuThuoc) * int.Parse(paramsThamSo.GiamTruNPT);
                    newModel.GiamTruNguoiPhuThuoc = total1.ToString();
                    int total2 = int.Parse(item.LuongThoaThuan) - int.Parse(paramsThamSo.GiamTruBanThan) - int.Parse(paramsThamSo.GiamTruNPT);
                    newModel.ThuNhapTinhThue = total2.ToString();
                    foreach (var item1 in listTNCN)
                    {
                        var a = int.Parse(item1.Tu);
                        var b = int.Parse(item1.Den);
                        if (total2 >= a && total2 <= b)
                        {
                            var c = float.Parse(item1.ThueSuat);
                            float total3 = total2 * c;
                            newModel.ThueTNCN = total3.ToString();
                        }
                    }
                    listModel.Add(newModel);
                }
                ViewBag.ListTNCN = listModel;
                return View(ViewBag.ListTNCN);
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
