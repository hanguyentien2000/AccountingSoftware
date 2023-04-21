namespace AccountingSoftware.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ThueTNCN")]
    public partial class ThueTNCN
    {
        [Key]
        public int MaThueTNCN { get; set; }

        public int BacThue { get; set; }

        public int MaNV { get; set; }

        [Required]
        [StringLength(100)]
        public string Tu { get; set; }

        [Required]
        [StringLength(100)]
        public string Den { get; set; }

        [Required]
        [StringLength(100)]
        public string ThueSuat { get; set; }

    }
}
