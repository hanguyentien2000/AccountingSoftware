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
                    int total1 = int.Parse(item.LuongCoBan) * int.Parse(paramsThamSo.TLBHXH);
                    newModel.BHXH = total1.ToString();
                    int total2 = int.Parse(item.LuongCoBan) * int.Parse(paramsThamSo.TLBHTN);
                    newModel.BHTN = total2.ToString();
                    int total3 = int.Parse(item.LuongCoBan) * int.Parse(paramsThamSo.TLBHYT);
                    newModel.BHYT = total3.ToString();
                    int total6 = int.Parse(item.LuongCoBan) * int.Parse(paramsThamSo.TLKPCD);
                    newModel.KPCD = total6.ToString();
                    int total7 = int.Parse(item.LuongThoaThuan) - int.Parse(paramsThamSo.GiamTruBanThan) - int.Parse(paramsThamSo.GiamTruNPT);
                    newModel.ThuNhapTinhThue = total7.ToString();
                    foreach (var item1 in listTNCN)
                    {
                        var a = int.Parse(item1.Tu);
                        var b = int.Parse(item1.Den);
                        if (total7 >= a && total7 <= b)
                        {
                            newModel.ThueSuat = item1.ThueSuat;
                            float total4 = (int.Parse(item.LuongThoaThuan) - int.Parse(paramsThamSo.GiamTruBanThan)) * float.Parse(item1.ThueSuat);
                            newModel.KhauTruThueTNCN = total4.ToString();
                        }
                    }
                    newModel.DanhGiaHieuQua = soCong.DGHQCN;
                    float total5 = ((int.Parse(item.LuongCoBan) / int.Parse(paramsThamSo.CongLuong)) * int.Parse(soCong.SoNgayCongThucTe) - (total1 + total2 + total3) - float.Parse(newModel.KhauTruThueTNCN)) * int.Parse(soCong.DGHQCN);
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

                LocalReport localReport = new LocalReport();
                localReport.ReportPath = Server.MapPath("~/Areas/Administrator/Reports/BaoCaoBangLuong.rdlc");
                ReportDataSource reportDataSource = new ReportDataSource();
                reportDataSource.Name = "BaoCaoBangLuong";
                reportDataSource.Value = ViewBag.ListBCBL;
                localReport.DataSources.Add(reportDataSource);
                string reportType = "Word";
                string mimeType;
                string encoding;
                string filenameExtension;
                filenameExtension = "docx";

                string[] streams;
                Microsoft.Reporting.WebForms.Warning[] warnings;
                byte[] renderedByte;
                renderedByte = localReport.Render(reportType, "", out mimeType, out encoding, out filenameExtension,
                    out streams, out warnings);
                Response.AddHeader("content-disposition", "attachment;filename= baoCaoBangLuong_report." + filenameExtension);
                return File(renderedByte, filenameExtension);
            }
        }

        [HttpPost]
        [ValidateInput(false)]
        public EmptyResult Export(string GridHtml)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=Grid.doc");
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
