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

        [Required]
        [StringLength(100)]
        public string ThangCC { get; set; }

        public int MaNV { get; set; }

        public int NgayCongDiLam { get; set; }

        public int NgayCongNghiPhep { get; set; }

        [Required]
        [StringLength(100)]
        public string XepLoai { get; set; }

        [Required]
        [StringLength(100)]
        public string NgayThuongThem { get; set; }

        [Required]
        [StringLength(100)]
        public string NgayLeThem { get; set; }

        public virtual NhanVien NhanVien { get; set; }
    }
}
