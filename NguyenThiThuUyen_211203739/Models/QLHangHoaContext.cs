﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace NguyenThiThuUyen_211203739.Models
{
    public partial class QLHangHoaContext : DbContext
    {
        public QLHangHoaContext()
        {
        }

        public QLHangHoaContext(DbContextOptions<QLHangHoaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<HangHoa> HangHoas { get; set; } = null!;
        public virtual DbSet<LoaiHang> LoaiHangs { get; set; } = null!;
        public virtual DbSet<TblAccount> TblAccounts { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=LAPTOP-KQVKE8JK\\SQLEXPRESS01;Initial Catalog=QLHangHoa;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HangHoa>(entity =>
            {
                entity.HasKey(e => e.MaHang);

                entity.ToTable("HangHoa");

                entity.Property(e => e.Anh).HasMaxLength(100);

                entity.Property(e => e.Gia).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.TenHang).HasMaxLength(50);

                entity.HasOne(d => d.MaLoaiNavigation)
                    .WithMany(p => p.HangHoas)
                    .HasForeignKey(d => d.MaLoai)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HangHoa_LoaiHang");
            });

            modelBuilder.Entity<LoaiHang>(entity =>
            {
                entity.HasKey(e => e.MaLoai);

                entity.ToTable("LoaiHang");

                entity.Property(e => e.TenLoai).HasMaxLength(50);
            });

            modelBuilder.Entity<TblAccount>(entity =>
            {
                entity.HasKey(e => e.Uid);

                entity.ToTable("tblAccount");

                entity.Property(e => e.Password)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Username)
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
