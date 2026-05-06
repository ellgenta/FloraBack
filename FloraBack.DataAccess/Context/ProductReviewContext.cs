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
    }
}