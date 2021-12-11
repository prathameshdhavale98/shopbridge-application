using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebAPI201.Domain.Entities
{
    [ExcludeFromCodeCoverage]
    public partial class ShopBridgeManagementContext : DbContext
    {
        public ShopBridgeManagementContext()
        {
        }

        public ShopBridgeManagementContext(DbContextOptions<ShopBridgeManagementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ShopBridgeProducts> ShopBridgeProducts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=A2ML37325\\SQLEXPRESS;Database=ShopBridgeManagement;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ShopBridgeProducts>(entity =>
            {
                entity.HasKey(e => e.ProductId);

                entity.Property(e => e.ProductId).HasColumnName("ProductId");

                entity.Property(e => e.ProductName).HasColumnName("ProductName");

                entity.Property(e => e.ProductDescription).HasColumnName("ProductDescription");

                entity.Property(e => e.Price).HasColumnName("Price");

                entity.Property(e => e.ProductRatings).HasColumnName("ProductRatings");

                entity.Property(e => e.ProductReviews).HasColumnName("ProductReviews");
            });
        }
    }
}
