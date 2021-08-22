using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BTL_Csharp_Nhom8.Models
{
    public partial class QLCuaHangTapHoaContext : DbContext
    {
        public QLCuaHangTapHoaContext()
        {
        }

        public QLCuaHangTapHoaContext(DbContextOptions<QLCuaHangTapHoaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DanhmucSp> DanhmucSps { get; set; }
        public virtual DbSet<Dongpnhap> Dongpnhaps { get; set; }
        public virtual DbSet<Dongpxuat> Dongpxuats { get; set; }
        public virtual DbSet<Khachhang> Khachhangs { get; set; }
        public virtual DbSet<Nhacc> Nhaccs { get; set; }
        public virtual DbSet<Nhanvien> Nhanviens { get; set; }
        public virtual DbSet<Pnhap> Pnhaps { get; set; }
        public virtual DbSet<Pxuat> Pxuats { get; set; }
        public virtual DbSet<Sanpham> Sanphams { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=QLCuaHangTapHoa;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<DanhmucSp>(entity =>
            {
                entity.HasKey(e => e.Madm)
                    .HasName("PK__DANHMUC___603F005CAAFD868F");

                entity.ToTable("DANHMUC_SP");

                entity.Property(e => e.Madm)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MADM")
                    .IsFixedLength(true);

                entity.Property(e => e.Tendm)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("TENDM");
            });

            modelBuilder.Entity<Dongpnhap>(entity =>
            {
                entity.HasKey(e => new { e.Masp, e.Mapn })
                    .HasName("PK__DONGPNHA__96217C2E4779C84A");

                entity.ToTable("DONGPNHAP");

                entity.Property(e => e.Masp)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MASP")
                    .IsFixedLength(true);

                entity.Property(e => e.Mapn)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MAPN")
                    .IsFixedLength(true);

                entity.Property(e => e.Dongianhap).HasColumnName("DONGIANHAP");

                entity.Property(e => e.Soluongnhap).HasColumnName("SOLUONGNHAP");

                entity.HasOne(d => d.MapnNavigation)
                    .WithMany(p => p.Dongpnhaps)
                    .HasForeignKey(d => d.Mapn)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DONGPNHAP__MAPN__37A5467C");

                entity.HasOne(d => d.MaspNavigation)
                    .WithMany(p => p.Dongpnhaps)
                    .HasForeignKey(d => d.Masp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DONGPNHAP__MASP__34C8D9D1");
            });

            modelBuilder.Entity<Dongpxuat>(entity =>
            {
                entity.HasKey(e => new { e.Mapx, e.Masp })
                    .HasName("PK__DONGPXUA__563D497B5F3C7C87");

                entity.ToTable("DONGPXUAT");

                entity.Property(e => e.Mapx)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MAPX")
                    .IsFixedLength(true);

                entity.Property(e => e.Masp)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MASP")
                    .IsFixedLength(true);

                entity.Property(e => e.Dongiaxuat).HasColumnName("DONGIAXUAT");

                entity.Property(e => e.Soluongxuat).HasColumnName("SOLUONGXUAT");

                entity.HasOne(d => d.MapxNavigation)
                    .WithMany(p => p.Dongpxuats)
                    .HasForeignKey(d => d.Mapx)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DONGPXUAT__MAPX__38996AB5");

                entity.HasOne(d => d.MaspNavigation)
                    .WithMany(p => p.Dongpxuats)
                    .HasForeignKey(d => d.Masp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DONGPXUAT__MASP__35BCFE0A");
            });

            modelBuilder.Entity<Khachhang>(entity =>
            {
                entity.HasKey(e => e.Makh)
                    .HasName("PK__KHACHHAN__603F592CB38B74C2");

                entity.ToTable("KHACHHANG");

                entity.Property(e => e.Makh)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MAKH")
                    .IsFixedLength(true);

                entity.Property(e => e.Gioitnh).HasColumnName("GIOITNH");

                entity.Property(e => e.Sdt)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("SDT")
                    .IsFixedLength(true);

                entity.Property(e => e.Tenkh)
                    .IsRequired()
                    .HasMaxLength(25)
                    .HasColumnName("TENKH");
            });

            modelBuilder.Entity<Nhacc>(entity =>
            {
                entity.HasKey(e => e.Mancc)
                    .HasName("PK__NHACC__7ABEA5825587FEA4");

                entity.ToTable("NHACC");

                entity.Property(e => e.Mancc)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MANCC")
                    .IsFixedLength(true);

                entity.Property(e => e.Diachi)
                    .HasMaxLength(100)
                    .HasColumnName("DIACHI");

                entity.Property(e => e.Sodt)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("SODT")
                    .IsFixedLength(true);

                entity.Property(e => e.Tenncc)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("TENNCC");
            });

            modelBuilder.Entity<Nhanvien>(entity =>
            {
                entity.HasKey(e => e.Manv)
                    .HasName("PK__NHANVIEN__603F5114A81284A7");

                entity.ToTable("NHANVIEN");

                entity.Property(e => e.Manv)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MANV")
                    .IsFixedLength(true);

                entity.Property(e => e.Diachi)
                    .HasMaxLength(100)
                    .HasColumnName("DIACHI");

                entity.Property(e => e.Gioitnh).HasColumnName("GIOITNH");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("PASSWORD");

                entity.Property(e => e.Sodt)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("SODT")
                    .IsFixedLength(true);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");

                entity.Property(e => e.Tennv)
                    .IsRequired()
                    .HasMaxLength(25)
                    .HasColumnName("TENNV");
            });

            modelBuilder.Entity<Pnhap>(entity =>
            {
                entity.HasKey(e => e.Mapn)
                    .HasName("PK__PNHAP__603F61CE141D29F1");

                entity.ToTable("PNHAP");

                entity.Property(e => e.Mapn)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MAPN")
                    .IsFixedLength(true);

                entity.Property(e => e.Mancc)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MANCC")
                    .IsFixedLength(true);

                entity.Property(e => e.Manv)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MANV")
                    .IsFixedLength(true);

                entity.Property(e => e.Ngaynhap)
                    .HasColumnType("date")
                    .HasColumnName("NGAYNHAP");

                entity.HasOne(d => d.ManccNavigation)
                    .WithMany(p => p.Pnhaps)
                    .HasForeignKey(d => d.Mancc)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PNHAP__MANCC__36B12243");

                entity.HasOne(d => d.ManvNavigation)
                    .WithMany(p => p.Pnhaps)
                    .HasForeignKey(d => d.Manv)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PNHAP__MANV__398D8EEE");
            });

            modelBuilder.Entity<Pxuat>(entity =>
            {
                entity.HasKey(e => e.Mapx)
                    .HasName("PK__PXUAT__603F61D8E8BD0751");

                entity.ToTable("PXUAT");

                entity.Property(e => e.Mapx)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MAPX")
                    .IsFixedLength(true);

                entity.Property(e => e.Makh)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MAKH")
                    .IsFixedLength(true);

                entity.Property(e => e.Manv)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MANV")
                    .IsFixedLength(true);

                entity.Property(e => e.Ngayxuat)
                    .HasColumnType("date")
                    .HasColumnName("NGAYXUAT");

                entity.HasOne(d => d.MakhNavigation)
                    .WithMany(p => p.Pxuats)
                    .HasForeignKey(d => d.Makh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PXUAT__MAKH__3B75D760");

                entity.HasOne(d => d.ManvNavigation)
                    .WithMany(p => p.Pxuats)
                    .HasForeignKey(d => d.Manv)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PXUAT__MANV__3A81B327");
            });

            modelBuilder.Entity<Sanpham>(entity =>
            {
                entity.HasKey(e => e.Masp)
                    .HasName("PK__SANPHAM__60228A3222B33E13");

                entity.ToTable("SANPHAM");

                entity.Property(e => e.Masp)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MASP")
                    .IsFixedLength(true);

                entity.Property(e => e.Hansd)
                    .HasColumnType("date")
                    .HasColumnName("HANSD");

                entity.Property(e => e.Madm)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MADM")
                    .IsFixedLength(true);

                entity.Property(e => e.Mota)
                    .HasMaxLength(50)
                    .HasColumnName("MOTA");

                entity.Property(e => e.Sl).HasColumnName("SL");

                entity.Property(e => e.Tensp)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("TENSP");

                entity.HasOne(d => d.MadmNavigation)
                    .WithMany(p => p.Sanphams)
                    .HasForeignKey(d => d.Madm)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SANPHAM__MADM__33D4B598");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
