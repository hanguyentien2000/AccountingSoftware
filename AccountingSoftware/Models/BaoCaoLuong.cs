using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AccountingSoftware.Models
{
    public class BaoCaoBangLuong
    {
        public int MaNV { get; set; }
        public string HoTen { get; set; }
        public string LuongCoBan { get; set; }
        public string LuongThoaThuan { get; set; }
        public string CongLuong { get; set; }
        public string SoNgayCongThucTe { get; set; }

        public string BHXH { get; set; }
        public string BHYT { get; set; }
        public string BHTN { get; set; }
        public string KPCD { get; set; }
        public string KhauTruThueTNCN { get; set; }
        public string DanhGiaHieuQua { get; set; }
        public string ThucLinh { get; set; }
    }
}