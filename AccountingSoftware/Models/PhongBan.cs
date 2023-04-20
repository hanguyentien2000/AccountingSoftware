namespace AccountingSoftware.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhongBan")]
    public partial class PhongBan
    {
        [Key]
        public int MaPhongBan { get; set; }

        [Required]
        [StringLength(100)]
        public string TenPhongBan { get; set; }

        [Required]
        [StringLength(100)]
        public string SDT { get; set; }
    }
}
