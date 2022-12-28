using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace prjMVC_Core.Models
{
    public partial class dbDemoContext : DbContext
    {
        public dbDemoContext()
        {
        }

        public dbDemoContext(DbContextOptions<dbDemoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TPainent> TPainents { get; set; } = null!;
        public virtual DbSet<TProduct> TProducts { get; set; } = null!;
        public virtual DbSet<TTransaction> TTransactions { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=dbDemo;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TPainent>(entity =>
            {
                entity.HasKey(e => e.Fld);

                entity.ToTable("tPainent");

                entity.Property(e => e.Fld).HasColumnName("fld");

                entity.Property(e => e.FAddress)
                    .HasMaxLength(50)
                    .HasColumnName("fAddress");

                entity.Property(e => e.FEmail)
                    .HasMaxLength(50)
                    .HasColumnName("fEmail");

                entity.Property(e => e.FName)
                    .HasMaxLength(50)
                    .HasColumnName("fName");

                entity.Property(e => e.FPassword)
                    .HasMaxLength(50)
                    .HasColumnName("fPassword");

                entity.Property(e => e.FPhone)
                    .HasMaxLength(50)
                    .HasColumnName("fPhone");

                entity.Property(e => e.F健保卡號)
                    .HasMaxLength(50)
                    .HasColumnName("f健保卡號");

                entity.Property(e => e.F身分證號)
                    .HasMaxLength(50)
                    .HasColumnName("f身分證號");
            });

            modelBuilder.Entity<TProduct>(entity =>
            {
                entity.HasKey(e => e.FId);

                entity.ToTable("tProduct");

                entity.Property(e => e.FId).HasColumnName("fId");

                entity.Property(e => e.FCost)
                    .HasColumnType("money")
                    .HasColumnName("fCost");

                entity.Property(e => e.FName)
                    .HasMaxLength(50)
                    .HasColumnName("fName");

                entity.Property(e => e.FPhotoPath)
                    .HasMaxLength(50)
                    .HasColumnName("fPhotoPath");

                entity.Property(e => e.FPrice)
                    .HasColumnType("money")
                    .HasColumnName("fPrice");

                entity.Property(e => e.FQty).HasColumnName("fQty");
            });

            modelBuilder.Entity<TTransaction>(entity =>
            {
                entity.HasKey(e => e.FId);

                entity.ToTable("tTransaction");

                entity.Property(e => e.FId).HasColumnName("fId");

                entity.Property(e => e.FCount).HasColumnName("fCount");

                entity.Property(e => e.FCustomerId).HasColumnName("fCustomerId");

                entity.Property(e => e.FDate)
                    .HasMaxLength(50)
                    .HasColumnName("fDate");

                entity.Property(e => e.FPrice)
                    .HasColumnType("money")
                    .HasColumnName("fPrice");

                entity.Property(e => e.FProductId).HasColumnName("fProductId");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
