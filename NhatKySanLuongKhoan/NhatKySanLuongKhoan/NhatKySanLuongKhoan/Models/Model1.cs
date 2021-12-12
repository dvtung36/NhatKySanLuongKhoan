namespace NhatKySanLuongKhoan.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model11")
        {
        }

        public virtual DbSet<CV> CVs { get; set; }
        public virtual DbSet<NHANCONG> NHANCONGs { get; set; }
        public virtual DbSet<NKSLK> NKSLKs { get; set; }
        public virtual DbSet<SANPHAM> SANPHAMs { get; set; }
        public virtual DbSet<DMCV> DMCVs { get; set; }
        public virtual DbSet<DMNC> DMNCs { get; set; }
        public virtual DbSet<Sogiocuakhoan_v> Sogiocuakhoan_v { get; set; }
        public virtual DbSet<Sogionhanvienlamtungchung_v> Sogionhanvienlamtungchung_v { get; set; }
        public virtual DbSet<Tylelamviec_v> Tylelamviec_v { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CV>()
                .Property(e => e.MaCV)
                .IsUnicode(false);

            modelBuilder.Entity<CV>()
                .Property(e => e.MaSP)
                .IsUnicode(false);

            modelBuilder.Entity<CV>()
                .HasMany(e => e.DMCVs)
                .WithRequired(e => e.CV)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NHANCONG>()
                .Property(e => e.MaNC)
                .IsUnicode(false);

            modelBuilder.Entity<NHANCONG>()
                .HasMany(e => e.DMNCs)
                .WithRequired(e => e.NHANCONG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NKSLK>()
                .Property(e => e.MaKhoan)
                .IsUnicode(false);

            modelBuilder.Entity<NKSLK>()
                .HasMany(e => e.DMCVs)
                .WithRequired(e => e.NKSLK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NKSLK>()
                .HasMany(e => e.DMNCs)
                .WithRequired(e => e.NKSLK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SANPHAM>()
                .Property(e => e.MaSP)
                .IsUnicode(false);

            modelBuilder.Entity<SANPHAM>()
                .Property(e => e.SoDK)
                .IsUnicode(false);

            modelBuilder.Entity<SANPHAM>()
                .Property(e => e.HanSD)
                .IsUnicode(false);

            modelBuilder.Entity<SANPHAM>()
                .Property(e => e.NgayDangKy)
                .IsUnicode(false);

            modelBuilder.Entity<SANPHAM>()
                .HasMany(e => e.CVs)
                .WithRequired(e => e.SANPHAM)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DMCV>()
                .Property(e => e.MaCV)
                .IsUnicode(false);

            modelBuilder.Entity<DMCV>()
                .Property(e => e.MaKhoan)
                .IsUnicode(false);

            modelBuilder.Entity<DMNC>()
                .Property(e => e.MaKhoan)
                .IsUnicode(false);

            modelBuilder.Entity<DMNC>()
                .Property(e => e.MaNC)
                .IsUnicode(false);

            modelBuilder.Entity<Sogiocuakhoan_v>()
                .Property(e => e.MaKhoan)
                .IsUnicode(false);

            modelBuilder.Entity<Sogionhanvienlamtungchung_v>()
                .Property(e => e.MaKhoan)
                .IsUnicode(false);

            modelBuilder.Entity<Sogionhanvienlamtungchung_v>()
                .Property(e => e.MaNC)
                .IsUnicode(false);

            modelBuilder.Entity<Tylelamviec_v>()
                .Property(e => e.MaKhoan)
                .IsUnicode(false);

            modelBuilder.Entity<Tylelamviec_v>()
                .Property(e => e.MaNC)
                .IsUnicode(false);
        }
    }
}
