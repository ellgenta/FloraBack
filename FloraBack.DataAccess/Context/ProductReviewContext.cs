using FloraBack.Domains.Entities.Product;
using FloraBack.Domains.Entities.ProductReview;
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
            modelBuilder.Entity<ProductData>()
                .ToTable("Products", t => t.ExcludeFromMigrations());

            modelBuilder.Entity<ProductData>()
                .Ignore(p => p.Images);

            modelBuilder.Entity<ProductData>()
                .Ignore(p => p.Description);

            modelBuilder.Entity<ProductData>()
                .Ignore(p => p.Category);

            modelBuilder.Entity<ProductReviewData>()
                .HasOne(r => r.Product)
                .WithMany()
                .HasForeignKey(r => r.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}