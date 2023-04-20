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

        public int NgayCongDiLam { get; set; }

        public int GioCongTrongNgay { get; set; }

        [Required]
        [StringLength(100)]
        public string HeSoNgayThuong { get; set; }

        [Required]
        [StringLength(100)]
        public string HeSoNgayLe { get; set; }

        [Required]
        [StringLength(100)]
        public string ThuLaoBHXH { get; set; }

        [Required]
        [StringLength(100)]
        public string ThuLaoBHYT { get; set; }

        [Required]
        [StringLength(100)]
        public string ThuLaoBHTN { get; set; }

        [Required]
        [StringLength(100)]
        public string ThuLaoKPCD { get; set; }

        [Required]
        [StringLength(100)]
        public string GiamTruBanThan { get; set; }

        [Required]
        [StringLength(100)]
        public string GiamTruNPT { get; set; }

        public virtual NhanVien NhanVien { get; set; }
    }
}
