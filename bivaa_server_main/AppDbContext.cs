using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace bivaa_server_main
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext()
            : base("name=AppDbContext")
        {
            Configuration.LazyLoadingEnabled = false;
        }

        public virtual DbSet<brand> brand { get; set; }
        public virtual DbSet<customer> customer { get; set; }
        public virtual DbSet<discount_code> discount_code { get; set; }
        public virtual DbSet<sales_order> sales_order { get; set; }
        public virtual DbSet<sales_order_item> sales_order_item { get; set; }
        public virtual DbSet<stock_item> stock_item { get; set; }
        public virtual DbSet<stock_item_dimension> stock_item_dimension { get; set; }
        public virtual DbSet<tax_rate> tax_rate { get; set; }
        public virtual DbSet<user> user { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<brand>()
                .Property(e => e.code)
                .IsUnicode(false);

            modelBuilder.Entity<brand>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<brand>()
                .HasMany(e => e.sales_order)
                .WithRequired(e => e.brand)
                .HasForeignKey(e => e.brand_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<customer>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<customer>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<customer>()
                .HasMany(e => e.sales_order)
                .WithRequired(e => e.customer)
                .HasForeignKey(e => e.customer_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<discount_code>()
                .Property(e => e.code)
                .IsUnicode(false);

            modelBuilder.Entity<discount_code>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<discount_code>()
                .HasMany(e => e.sales_order)
                .WithMany(e => e.discount_code)
                .Map(m => m.ToTable("sales_order_discount_code", "bivaa_example_eshop"));

            modelBuilder.Entity<sales_order>()
                .Property(e => e.type)
                .IsUnicode(false);

            modelBuilder.Entity<sales_order>()
                .HasMany(e => e.sales_order_item)
                .WithRequired(e => e.sales_order)
                .HasForeignKey(e => e.sales_order_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<stock_item>()
                .Property(e => e.code)
                .IsUnicode(false);

            modelBuilder.Entity<stock_item>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<stock_item>()
                .HasMany(e => e.sales_order_item)
                .WithRequired(e => e.stock_item)
                .HasForeignKey(e => e.stock_item_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<stock_item_dimension>()
                .HasMany(e => e.stock_item)
                .WithRequired(e => e.stock_item_dimension)
                .HasForeignKey(e => e.stock_item_dimension_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tax_rate>()
                .Property(e => e.code)
                .IsUnicode(false);

            modelBuilder.Entity<tax_rate>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<tax_rate>()
                .HasMany(e => e.brand)
                .WithRequired(e => e.tax_rate)
                .HasForeignKey(e => e.default_tax_rate_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<user>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.password)
                .IsUnicode(false);
        }
    }
}
