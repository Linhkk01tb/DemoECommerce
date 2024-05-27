using DemoECommercePrj.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoECommercePrj.Data


{
    public class DemoEcommerceDbContext : DbContext
    {
        public DemoEcommerceDbContext(DbContextOptions<DemoEcommerceDbContext> options) : base(options) { }

        #region DbSet
        /// <summary>
        /// Category
        /// </summary>
        public DbSet<Category> Categories { get; set; }

        /// <summary>
        /// Brand
        /// </summary>
        //public DbSet<Brand> Brands { get; set; }

        /// <summary>
        /// Product
        /// </summary>
        public DbSet<Product> Products { get; set; }

        /// <summary>
        /// Order
        /// </summary>
        //public DbSet<Order> Orders { get; set; }

        /// <summary>
        /// OrderDetail
        /// </summary>
        //public DbSet<OrderDetail> OrderDetails { get; set; }

        /// <summary>
        /// User
        /// </summary>
        //public DbSet<User> Users { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(ent =>
            {
                ent.ToTable("Categories");
                ent.HasKey(ct => ct.CategoryId);
                ent.Property(ct => ct.CategoryName).HasMaxLength(50).IsRequired(true);
                ent.HasIndex(ct => ct.CategoryName).IsUnique(true);
            });

            modelBuilder.Entity<Product>(ent =>
            {
                ent.ToTable("Products");
                ent.HasKey(pd => pd.ProductId);
                ent.HasOne<Category>(pd => pd.Category).WithMany(pd => pd.Products).HasForeignKey(pd => pd.CategoryId).HasConstraintName("FK_Product_Category");
                ent.Property(pd => pd.ProductName).HasMaxLength(100).IsRequired(true);
                ent.Property(pd => pd.ProductQuantiy).IsRequired(true);
                ent.Property(pd => pd.ProductPrice).IsRequired(true);
                ent.HasIndex(pd => pd.ProductName).IsUnique(true);

            });

            //modelBuilder.Entity<Order>(ent =>
            //{
            //    ent.ToTable("Orders");
            //    ent.HasKey(od => od.OrderId);
            //    ent.Property(od=>od.ReceivedName).HasMaxLength(100).IsRequired(true);
            //    ent.Property(od => od.ReceivedPhoneNumber).HasMaxLength(20).IsRequired(true);
            //    ent.Property(od => od.ReceivedEmail).HasMaxLength(100).IsRequired(true);
            //});
        }

    }
}
