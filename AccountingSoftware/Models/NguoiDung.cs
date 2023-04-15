namespace AccountingSoftware.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NguoiDung")]
    public partial class NguoiDung
    {
        [Key]
        public int MaNguoiDung { get; set; }

        [Required]
        [StringLength(100)]
        public string TenNguoiDung { get; set; }

        [Required]
        [StringLength(100)]
        public string MatKhau { get; set; }

        public bool QuanTri { get; set; }
    }
}
