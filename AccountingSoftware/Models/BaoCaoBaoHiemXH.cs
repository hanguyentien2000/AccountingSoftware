using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AccountingSoftware.Models
{
    public class BaoCaoBaoHiemXH
    {
        public int MaNV { get; set; }
        public string HoTen { get; set; }
        public string LuongCoBan { get; set; }
        public string TLBHXH { get; set; }
        public string TLBHYT { get; set; }
        public string TLBHTN { get; set; }

        public string MucChiTraTLBHXH { get; set; }
        public string MucChiTraTLBHYT { get; set; }
        public string MucChiTraTLBHTN { get; set; }
        public string TongTien { get; set; }
    }
}