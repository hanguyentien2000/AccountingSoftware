using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace AccountingSoftware.Models
{
    public partial class AccountingSoftwareDbContext : DbContext
    {
        public AccountingSoftwareDbContext()
            : base("name=AccountingSoftwareDbContext")
        {
        }

        public virtual DbSet<BangChamCong> BangChamCongs { get; set; }
        public virtual DbSet<ChucVu> ChucVus { get; set; }
        public virtual DbSet<NguoiDung> NguoiDungs { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<PhongBan> PhongBans { get; set; }
        public virtual DbSet<TangGiamLuong> TangGiamLuongs { get; set; }
        public virtual DbSet<ThamSoTinhLuong> ThamSoTinhLuongs { get; set; }
        public virtual DbSet<ThueTNCN> ThueTNCNs { get; set; }
        public virtual DbSet<TTCongTy> TTCongTies { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {


            modelBuilder.Entity<NhanVien>()
                .HasMany(e => e.BangChamCongs)
                .WithRequired(e => e.NhanVien)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NhanVien>()
                .HasMany(e => e.TangGiamLuongs)
                .WithRequired(e => e.NhanVien)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NhanVien>()
                .HasMany(e => e.ThamSoTinhLuongs)
                .WithRequired(e => e.NhanVien)
                .WillCascadeOnDelete(false);

          
        }
    }
}
