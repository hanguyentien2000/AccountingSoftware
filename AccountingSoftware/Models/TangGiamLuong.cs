namespace AccountingSoftware.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TangGiamLuong")]
    public partial class TangGiamLuong
    {
        [Key]
        public int MaTangGiamLuong { get; set; }

        public int MaNV { get; set; }

        [Required]
        [StringLength(100)]
        public string NgayThang { get; set; }

        [Required]
        [StringLength(100)]
        public string TaiKhoanNo { get; set; }

        [Required]
        [StringLength(100)]
        public string TaiKhoanChinh { get; set; }

        [Required]
        [StringLength(100)]
        public string SoTien { get; set; }

        [Required]
        [StringLength(100)]
        public string ThongTin { get; set; }

        public virtual NhanVien NhanVien { get; set; }
    }
}
