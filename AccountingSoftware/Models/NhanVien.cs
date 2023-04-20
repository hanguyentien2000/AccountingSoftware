namespace AccountingSoftware.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhanVien")]
    public partial class NhanVien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NhanVien()
        {
            BangChamCongs = new HashSet<BangChamCong>();
            TangGiamLuongs = new HashSet<TangGiamLuong>();
            ThamSoTinhLuongs = new HashSet<ThamSoTinhLuong>();
            ThueTNCNs = new HashSet<ThueTNCN>();
        }

        [Key]
        public int MaNV { get; set; }

        public int MaPhongBan { get; set; }

        public int MaChucVu { get; set; }

        [Required]
        [StringLength(100)]
        public string HoTen { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString =
          "{0:yyyy-MM-dd}",
          ApplyFormatInEditMode = true)]
        public DateTime NgaySinh { get; set; }

        public bool? GioiTinh { get; set; }

        [Required]
        [StringLength(100)]
        public string QueQuan { get; set; }

        [Required]
        [StringLength(100)]
        public string DiaChi { get; set; }

        [Required]
        [StringLength(100)]
        public string HeSoLuong { get; set; }

        [Required]
        [StringLength(100)]
        public string MaSoThue { get; set; }

        [Required]
        [StringLength(100)]
        public string SoNguoiPhuThuoc { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString =
          "{0:yyyy-MM-dd}",
          ApplyFormatInEditMode = true)]
        public DateTime NgayVaoLam { get; set; }

        [Required]
        [StringLength(100)]
        public string LuongThoaThuan { get; set; }

        [Required]
        [StringLength(100)]
        public string LuongCoBan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BangChamCong> BangChamCongs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TangGiamLuong> TangGiamLuongs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ThamSoTinhLuong> ThamSoTinhLuongs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ThueTNCN> ThueTNCNs { get; set; }
    }
}
