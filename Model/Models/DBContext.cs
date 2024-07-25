using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Model.Models
{
    public partial class DBContext : DbContext
    {
        public DBContext()
        {
        }

        public DBContext(DbContextOptions<DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Bill> Bills { get; set; }
        public virtual DbSet<BillDetails> BillDetails { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductCategory> ProductCategories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
                optionsBuilder.UseSqlServer(config.GetConnectionString("DBContext"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("Account");

                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.Name).HasMaxLength(100);
                entity.Property(e => e.Password).HasMaxLength(1000);
            });

            modelBuilder.Entity<Bill>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("Bill");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.DateBook)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime");
                entity.Property(e => e.DateCheckOut).HasColumnType("datetime");
                entity.Property(e => e.userID).HasColumnName("userID");
                entity.Property(e => e.Status).HasColumnName("status");
                entity.Property(e => e.TotalAmount).HasColumnName("totalAmount");
                
                entity.HasOne(d => d.IDUserNavigation).WithMany(p => p.Bills)
                    .HasForeignKey(d => d.userID);
            });

            modelBuilder.Entity<BillDetails>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("BillDetails");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.IdBill).HasColumnName("idBill");
                entity.Property(e => e.IdProduct).HasColumnName("idProduct");
                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.IdBillNavigation).WithMany(p => p.BillDetails)
                    .HasForeignKey(d => d.IdBill)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.BillDetails)
                    .HasForeignKey(d => d.IdProduct)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("Product");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.IdCategory).HasColumnName("idCategory");
                entity.Property(e => e.ImageLink)
                    .HasColumnType("text")
                    .HasColumnName("image_link");
                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasDefaultValue("Sản phẩm mới")
                    .HasColumnName("name");
                entity.Property(e => e.Price).HasColumnName("price");
                entity.Property(e => e.Quantity).HasDefaultValue(1).HasColumnName("quantity");
                entity.Property(e => e.Status).HasDefaultValue(true).HasColumnName("status");

                entity.HasOne(d => d.IdProductCategoryNavigation).WithMany(p => p.ListProducts)
                    .HasForeignKey(d => d.IdCategory)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<ProductCategory>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("ProductCategory");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
