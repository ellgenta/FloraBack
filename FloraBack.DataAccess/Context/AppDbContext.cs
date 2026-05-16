using FloraBack.Domains.Entities.Order;
using FloraBack.Domains.Entities.User;
using FloraBack.Domains.Entities.SiteReview;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FloraBack.Domains.Entities.Product;
using FloraBack.Domains.Entities.Cart;
using FloraBack.Domains.Entities.ProductReview;
using FloraBack.Domains.Entities.Category;
using FloraBack.Domains.Entities.Category;
namespace FloraBack.DataAccess.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<UserData> Users { get; set; }

        public DbSet<SiteReviewData> SiteReviews { get; set; }

        public DbSet<ProductReviewData> ProductReviews { get; set; }

        public DbSet<OrderData> Orders { get; set; }

        public DbSet<OrderItemData> OrderItems { get; set; }

        public DbSet<ProductData> Products { get; set; }

        public DbSet<ProductDescriptionData> Descriptions { get; set; }

        public DbSet<CategoryData> Categories { get; set; }

        public DbSet<SubCategoryData> SubCategories { get; set; }

        public DbSet<ProductImgData> Images { get; set; }

        public DbSet<CartData> Carts { get; set; }

        public DbSet<CartItemData> CartItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DbSession.ConnectionStrings);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
