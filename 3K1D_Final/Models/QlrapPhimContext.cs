using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace _3K1D_Final.Models;

public partial class QlrapPhimContext : DbContext
{
    public QlrapPhimContext()
    {
    }

    public QlrapPhimContext(DbContextOptions<QlrapPhimContext> options)
        : base(options)
    {
    }

    public virtual DbSet<KhachHang> KhachHangs { get; set; }

    public virtual DbSet<LichChieu> LichChieus { get; set; }

    public virtual DbSet<NhanVien> NhanViens { get; set; }

    public virtual DbSet<Phim> Phims { get; set; }

    public virtual DbSet<PhongChieu> PhongChieus { get; set; }

    public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }

    public virtual DbSet<TheLoai> TheLoais { get; set; }

    public virtual DbSet<Ve> Ves { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-0U55SOV\\SQLEXPRESS;Initial Catalog=QLRapPhim;Integrated Security=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<KhachHang>(entity =>
        {
            entity.HasKey(e => e.IdKhachHang).HasName("PK__KhachHan__DAF646D05922D236");

            entity.ToTable("KhachHang");

            entity.Property(e => e.IdKhachHang)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("idKhachHang");
            entity.Property(e => e.Cccd)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CCCD");
            entity.Property(e => e.DiaChi).HasMaxLength(100);
            entity.Property(e => e.HoTen).HasMaxLength(100);
            entity.Property(e => e.Sdt)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("SDT");
        });

        modelBuilder.Entity<LichChieu>(entity =>
        {
            entity.HasKey(e => e.IdLichChieu).HasName("PK__LichChie__A56F50C2925B885B");

            entity.ToTable("LichChieu");

            entity.Property(e => e.IdLichChieu)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("idLichChieu");
            entity.Property(e => e.GiaVe).HasColumnType("money");
            entity.Property(e => e.GioChieu).HasColumnType("datetime");
            entity.Property(e => e.IdPhim)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("idPhim");
            entity.Property(e => e.IdPhongChieu)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("idPhongChieu");
            entity.Property(e => e.TrangThai).HasDefaultValueSql("('0')");

            entity.HasOne(d => d.IdPhimNavigation).WithMany(p => p.LichChieus)
                .HasForeignKey(d => d.IdPhim)
                .HasConstraintName("FK_LichChieu_Phim");

            entity.HasOne(d => d.IdPhongChieuNavigation).WithMany(p => p.LichChieus)
                .HasForeignKey(d => d.IdPhongChieu)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__LichChieu__idPho__4BAC3F29");
        });

        modelBuilder.Entity<NhanVien>(entity =>
        {
            entity.HasKey(e => e.IdNv).HasName("PK__NhanVien__9DB8791C1F277B0E");

            entity.ToTable("NhanVien");

            entity.Property(e => e.IdNv)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("idNV");
            entity.Property(e => e.Cccd)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CCCD");
            entity.Property(e => e.DiaChi).HasMaxLength(100);
            entity.Property(e => e.HinhAnh).HasColumnType("image");
            entity.Property(e => e.HoTen).HasMaxLength(100);
            entity.Property(e => e.Sdt)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("SDT");
        });

        modelBuilder.Entity<Phim>(entity =>
        {
            entity.HasKey(e => e.IdPhim).HasName("PK__Phim__BFC6F6830AB23B79");

            entity.ToTable("Phim");

            entity.Property(e => e.IdPhim)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("idPhim");
            entity.Property(e => e.ApPhich).HasColumnType("image");
            entity.Property(e => e.DaoDien).HasMaxLength(100);
            entity.Property(e => e.DinhDangPhim)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.MoTa).HasMaxLength(1000);
            entity.Property(e => e.NamSx).HasColumnName("NamSX");
            entity.Property(e => e.QuocGiaSanXuat).HasMaxLength(50);
            entity.Property(e => e.TenPhim).HasMaxLength(100);

            entity.HasMany(d => d.IdTheLoais).WithMany(p => p.IdPhims)
                .UsingEntity<Dictionary<string, object>>(
                    "PhanLoaiPhim",
                    r => r.HasOne<TheLoai>().WithMany()
                        .HasForeignKey("IdTheLoai")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__PhanLoaiP__idThe__4E88ABD4"),
                    l => l.HasOne<Phim>().WithMany()
                        .HasForeignKey("IdPhim")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__PhanLoaiP__idPhi__4D94879B"),
                    j =>
                    {
                        j.HasKey("IdPhim", "IdTheLoai");
                        j.ToTable("PhanLoaiPhim");
                        j.IndexerProperty<string>("IdPhim")
                            .HasMaxLength(50)
                            .IsUnicode(false)
                            .HasColumnName("idPhim");
                        j.IndexerProperty<string>("IdTheLoai")
                            .HasMaxLength(50)
                            .IsUnicode(false)
                            .HasColumnName("idTheLoai");
                    });
        });

        modelBuilder.Entity<PhongChieu>(entity =>
        {
            entity.HasKey(e => e.IdPhongChieu).HasName("PK__PhongChi__A985F624C078777D");

            entity.ToTable("PhongChieu");

            entity.Property(e => e.IdPhongChieu)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("idPhongChieu");
            entity.Property(e => e.TenPhong).HasMaxLength(100);
        });

        modelBuilder.Entity<TaiKhoan>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("TaiKhoan");

            entity.Property(e => e.IdNv)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("idNV");
            entity.Property(e => e.LoaiTk)
                .HasDefaultValue(2)
                .HasColumnName("LoaiTK");
            entity.Property(e => e.Pass)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.UserName).HasMaxLength(100);

            entity.HasOne(d => d.IdNvNavigation).WithMany()
                .HasForeignKey(d => d.IdNv)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TaiKhoan__idNV__4F7CD00D");
        });

        modelBuilder.Entity<TheLoai>(entity =>
        {
            entity.HasKey(e => e.IdTheLoai).HasName("PK__TheLoai__890D7EC8109DE3D2");

            entity.ToTable("TheLoai");

            entity.Property(e => e.IdTheLoai)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("idTheLoai");
            entity.Property(e => e.MoTa).HasMaxLength(100);
            entity.Property(e => e.TenTheLoai).HasMaxLength(100);
        });

        modelBuilder.Entity<Ve>(entity =>
        {
            entity.HasKey(e => e.IdVe).HasName("PK__Ve__9DB83851E3384BEE");

            entity.ToTable("Ve");

            entity.Property(e => e.IdVe).HasColumnName("idVe");
            entity.Property(e => e.IdKhachHang)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("idKhachHang");
            entity.Property(e => e.IdLichChieu)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("idLichChieu");
            entity.Property(e => e.IdNv)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("idNV");
            entity.Property(e => e.LoaiVe).HasDefaultValueSql("('0')");
            entity.Property(e => e.MaGheNgoi)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NgayMua).HasColumnType("datetime");
            entity.Property(e => e.TienBanVe)
                .HasDefaultValueSql("('0')")
                .HasColumnType("money");
            entity.Property(e => e.TrangThai).HasDefaultValueSql("('0')");

            entity.HasOne(d => d.IdKhachHangNavigation).WithMany(p => p.Ves)
                .HasForeignKey(d => d.IdKhachHang)
                .HasConstraintName("FK__Ve__idKhachHang__5165187F");

            entity.HasOne(d => d.IdLichChieuNavigation).WithMany(p => p.Ves)
                .HasForeignKey(d => d.IdLichChieu)
                .HasConstraintName("FK__Ve__idLichChieu__52593CB8");

            entity.HasOne(d => d.IdNvNavigation).WithMany(p => p.Ves)
                .HasForeignKey(d => d.IdNv)
                .HasConstraintName("FK_Ve_NhanVien");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
