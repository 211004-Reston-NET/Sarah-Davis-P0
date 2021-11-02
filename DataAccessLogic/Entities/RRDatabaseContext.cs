using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DataAccessLogic.Entities
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
        public virtual DbSet<OrderPage> OrderPages { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Storefront> Storefronts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("customer");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.CustomerAddress)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("customer_address");

                entity.Property(e => e.CustomerEmail)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("customer_email");

                entity.Property(e => e.CustomerName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("customer_name");

                entity.Property(e => e.CustomerPassword)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("customer_password");

                entity.Property(e => e.CustomerPhoneNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("customer_phone_number");
            });

            modelBuilder.Entity<LineItem>(entity =>
            {
                entity.ToTable("line_item");

                entity.Property(e => e.LineItemId).HasColumnName("line_item_id");

                entity.Property(e => e.LineItemQuantity).HasColumnName("line_item_quantity");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.StorefrontId).HasColumnName("storefront_id");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.LineItems)
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

                entity.Property(e => e.LineItemOrderId).HasColumnName("line_item_order_id");

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

            modelBuilder.Entity<OrderPage>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PK__order_pa__46596229F5810271");

                entity.ToTable("order_page");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.OrderStorelocation)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("order_storelocation");

                entity.Property(e => e.OrderTotalprice)
                    .HasColumnType("money")
                    .HasColumnName("order_totalprice");

                entity.Property(e => e.StorefrontId).HasColumnName("storefront_id");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.OrderPages)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__order_pag__custo__693CA210");

                entity.HasOne(d => d.Storefront)
                    .WithMany(p => p.OrderPages)
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

                entity.Property(e => e.ProductPrice)
                    .HasColumnType("money")
                    .HasColumnName("product_price");
            });

            modelBuilder.Entity<Storefront>(entity =>
            {
                entity.ToTable("storefront");

                entity.Property(e => e.StorefrontId).HasColumnName("storefront_id");

                entity.Property(e => e.StorefrontAddress)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("storefront_address");

                entity.Property(e => e.StorefrontName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("storefront_name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
