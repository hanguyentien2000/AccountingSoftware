namespace AccountingSoftware.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TTCongTy")]
    public partial class TTCongTy
    {
        [Key]
        public int MaCT { get; set; }

        [Required]
        [StringLength(100)]
        public string TenCT { get; set; }

        [Required]
        [StringLength(100)]
        public string TGD { get; set; }

        [Required]
        [StringLength(100)]
        public string PGD { get; set; }

        [Required]
        [StringLength(100)]
        public string KTT { get; set; }
    }
}
