namespace AccountingSoftware.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ThamSoTinhLuong")]
    public partial class ThamSoTinhLuong
    {
        [Key]
        public int MaThamSo { get; set; }

        public int MaNV { get; set; }

        [Required]
        [StringLength(100)]
        public string ThangNam { get; set; }

        [Required]
        [StringLength(100)]
        public string LuongCB { get; set; }

        [Required]
        [StringLength(100)]
        public string NgcChuan { get; set; }

        [Required]
        [StringLength(100)]
        public string SoGioChuan { get; set; }

        [Required]
        [StringLength(100)]
        public string XepLoai { get; set; }

        [Required]
        [StringLength(100)]
        public string HsNgayThuong { get; set; }

        [Required]
        [StringLength(100)]
        public string HsNgayLe { get; set; }

        [Required]
        [StringLength(100)]
        public string PcAn { get; set; }

        [Required]
        [StringLength(100)]
        public string TLBHXH { get; set; }

        [Required]
        [StringLength(100)]
        public string TLBHYT { get; set; }

        [Required]
        [StringLength(100)]
        public string TLBHTN { get; set; }

        [Required]
        [StringLength(100)]
        public string TLKPCD { get; set; }

        public virtual NhanVien NhanVien { get; set; }
    }
}
