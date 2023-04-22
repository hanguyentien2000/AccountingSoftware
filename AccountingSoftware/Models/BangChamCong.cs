namespace AccountingSoftware.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BangChamCong")]
    public partial class BangChamCong
    {
        [Key]
        public int MaCC { get; set; }

        public int MaNV { get; set; }

        [Required]
        [StringLength(100)]
        public string SoNgayLVNgayThuong { get; set; }

        [Required]
        [StringLength(100)]
        public string SoNgayLVNgayLe { get; set; }

        [Required]
        [StringLength(100)]
        public string SoNgayLVNgayNghiPhep { get; set; }

        [Required]
        [StringLength(100)]
        public string SoNgayNghiKhongLuong { get; set; }

        [Required]
        [StringLength(100)]
        public string DGHQCN { get; set; }

        public virtual NhanVien NhanVien { get; set; }
    }
}
