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
                    newModel.GiamTruNguoiNop = paramsThamSo.GiamTruBanThan;
                    double total1 = double.Parse(item.SoNguoiPhuThuoc) * double.Parse(paramsThamSo.GiamTruNPT);
                    newModel.GiamTruNguoiPhuThuoc = total1.ToString();
                    double total2 = double.Parse(item.LuongThoaThuan) - double.Parse(paramsThamSo.GiamTruBanThan) - double.Parse(paramsThamSo.GiamTruNPT);
                    newModel.ThuNhapTinhThue = total2.ToString();
                    if (total2 < 0)
                        newModel.ThueTNCN = "0";
                    else if (total2 >= 0)
                    {
                        foreach (var item1 in listTNCN)
                        {
                            var a = double.Parse(item1.Tu);
                            var b = double.Parse(item1.Den);
                            if (total2 >= a && total2 <= b)
                            {
                                var c = double.Parse(item1.ThueSuat);
                                double total3 = total2 * c;
                                newModel.ThueTNCN = total3.ToString();
                            }
                        }
                    }
                    
                    listModel.Add(newModel);
                }
                ViewBag.ListTNCN = listModel;
                return View(ViewBag.ListTNCN);
            }
        }

        [HttpPost]
        [ValidateInput(false)]
        public EmptyResult Export(string GridHtml)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=BaoCaoThueTNCN.doc");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-word";
            Response.Output.Write(GridHtml);
            Response.Flush();
            Response.End();
            return new EmptyResult();
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
