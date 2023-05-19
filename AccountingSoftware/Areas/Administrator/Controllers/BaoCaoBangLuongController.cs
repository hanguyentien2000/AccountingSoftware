using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AccountingSoftware.Models;
using Microsoft.Reporting.WebForms;

namespace AccountingSoftware.Areas.Administrator.Controllers
{
    public class BaoCaoBangLuongController : Controller
    {
        private AccountingSoftwareDbContext db = new AccountingSoftwareDbContext();

        // GET: Administrator/BaoCaoLuong
        public ActionResult Index(string thang, string nam)
        {
            var listModel = new List<BaoCaoBangLuong>();
            var listTNCN = db.ThueTNCNs.ToList();
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
                    var newModel = new BaoCaoBangLuong();
                    var soCong = db.BangChamCongs.Where(x => x.MaNV == item.MaNV).FirstOrDefault();
                    newModel.HoTen = item.HoTen;
                    newModel.LuongThoaThuan = item.LuongThoaThuan;
                    newModel.LuongCoBan = item.LuongCoBan;
                    newModel.CongLuong = paramsThamSo.CongLuong;
                    newModel.SoNgayCongThucTe = soCong.SoNgayCongThucTe;
                    float total1 = float.Parse(item.LuongCoBan) * float.Parse(paramsThamSo.TLBHXH);
                    newModel.BHXH = total1.ToString();
                    float total2 = float.Parse(item.LuongCoBan) * float.Parse(paramsThamSo.TLBHTN);
                    newModel.BHTN = total2.ToString();
                    float total3 = float.Parse(item.LuongCoBan) * float.Parse(paramsThamSo.TLBHYT);
                    newModel.BHYT = total3.ToString();
                    float total6 = float.Parse(item.LuongCoBan) * float.Parse(paramsThamSo.TLKPCD);
                    newModel.KPCD = total6.ToString();
                    float total7 = float.Parse(item.LuongThoaThuan) - float.Parse(paramsThamSo.GiamTruBanThan) - float.Parse(paramsThamSo.GiamTruNPT);
                    newModel.ThuNhapTinhThue = total7.ToString();
                    foreach (var item1 in listTNCN)
                    {
                        var a = float.Parse(item1.Tu);
                        var b = float.Parse(item1.Den);
                        if (total7 >= a && total7 <= b)
                        {
                            newModel.ThueSuat = item1.ThueSuat;
                            float total4 = (float.Parse(item.LuongThoaThuan) - float.Parse(paramsThamSo.GiamTruBanThan)) * float.Parse(item1.ThueSuat);
                            newModel.KhauTruThueTNCN = total4.ToString();
                        }
                    }
                    newModel.DanhGiaHieuQua = soCong.DGHQCN;
                    float total5 = ((float.Parse(item.LuongCoBan) / float.Parse(paramsThamSo.CongLuong)) * float.Parse(soCong.SoNgayCongThucTe) - (total1 + total2 + total3) - float.Parse(newModel.KhauTruThueTNCN)) * float.Parse(soCong.DGHQCN);
                    newModel.ThucLinh = total5.ToString();
                    var listChucVu = db.ChucVus.ToList();
                    foreach (var item1 in listChucVu)
                    {
                        if (item.MaChucVu == item1.MaChucVu)
                            newModel.ChucVu = item1.TenChucVu;
                    }
                    listModel.Add(newModel);
                }
                ViewBag.ListBCBL = listModel;

                return View(ViewBag.ListBCBL);
            }
        }

        [HttpPost]
        [ValidateInput(false)]
        public EmptyResult Export(string GridHtml)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=BaoCaoBangLuong.doc");
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
