namespace AccountingSoftware.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChucVu")]
    public partial class ChucVu
    {
        [Key]
        public int MaChucVu { get; set; }

        [Required]
        [StringLength(100)]
        public string TenChucVu { get; set; }

        [Required]
        [StringLength(100)]
        public string HeSoPhuCapCV { get; set; }
    }
}
