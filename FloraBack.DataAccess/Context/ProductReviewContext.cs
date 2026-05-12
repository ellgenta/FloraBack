using FloraBack.Domains.Entities.Product;
using FloraBack.Domains.Entities.ProductReview;
using FloraBack.Domains.Entities.User;
using Microsoft.EntityFrameworkCore;

namespace FloraBack.DataAccess.Context
{
    public class ProductReviewContext : DbContext
    {
        public DbSet<ProductReviewData> ProductReviews { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DbSession.ConnectionStrings);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*
            modelBuilder.Entity<UserData>()
                .ToTable("Users")
                .Ignore(u => u.SiteReview)
                .Ignore(u => u.Cart)
                .Ignore(u => u.Orders);
            */

            modelBuilder.Entity<ProductReviewData>()
                .HasOne(r => r.User)
                .WithMany()
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ProductReviewData>()
                .HasOne(r => r.Product)
                .WithMany()
                .HasForeignKey(r => r.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}