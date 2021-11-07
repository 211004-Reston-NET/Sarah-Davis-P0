using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Models;

#nullable disable

namespace DataAccessLogic
{
    public partial class RRDatabaseContext : DbContext
    {
        public RRDatabaseContext()
        {
        }

        public RRDatabaseContext(DbContextOptions<RRDatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<LineItem> LineItems { get; set; }
        public virtual DbSet<LineItemOrder> LineItemOrders { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<StoreFront> Storefronts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("customer");

                entity.Property(e => e.Id).HasColumnName("customer_id");

                entity.Property(e => e.Address)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("customer_address");

                entity.Property(e => e.Email)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("customer_email");

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("customer_name");

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("customer_password");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("customer_phone_number");
            });

            modelBuilder.Entity<LineItem>(entity =>
            {
                entity.ToTable("line_item");

                entity.Property(e => e.LineItemId).HasColumnName("line_item_id");

                entity.Property(e => e.Quantity).HasColumnName("line_item_quantity");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.StorefrontId).HasColumnName("storefront_id");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.LineItem)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__line_item__produ__6477ECF3");

                entity.HasOne(d => d.Storefront)
                    .WithMany(p => p.LineItems)
                    .HasForeignKey(d => d.StorefrontId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__line_item__store__656C112C");
            });

            modelBuilder.Entity<LineItemOrder>(entity =>
            {
                entity.ToTable("line_item_order");

                entity.Property(e => e.LineItemOrderID).HasColumnName("line_item_order_id");

                entity.Property(e => e.LineItemId).HasColumnName("line_item_id");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.HasOne(d => d.LineItem)
                    .WithMany(p => p.LineItemOrders)
                    .HasForeignKey(d => d.LineItemId)
                    .HasConstraintName("FK__line_item__line___6C190EBB");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.LineItemOrders)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK__line_item__order__6D0D32F4");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PK__order_pa__46596229F5810271");

                entity.ToTable("order_page");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.StoreLocation)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("order_storelocation");

                entity.Property(e => e.TotalPrice)
                    .HasColumnType("money")
                    .HasColumnName("order_totalprice");

                entity.Property(e => e.StorefrontId).HasColumnName("storefront_id");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.ListOfOrders)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__order_pag__custo__693CA210");

                entity.HasOne(d => d.Storefront)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.StorefrontId)
                    .HasConstraintName("FK__order_pag__store__68487DD7");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("product");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.ProductCategory)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("product_category");

                entity.Property(e => e.ProductDescription)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("product_description");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("product_name");

                entity.Property(e => e.Price)
                    .HasColumnType("money")
                    .HasColumnName("product_price");
            });

            modelBuilder.Entity<StoreFront>(entity =>
            {
                entity.ToTable("storefront");

                entity.Property(e => e.StoreFrontId).HasColumnName("storefront_id");

                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("storefront_address");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("storefront_name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
