using FloraBack.Domains.Entities.Cart;
using FloraBack.Domains.Entities.Order;
using FloraBack.Domains.Entities.SiteReview;
using FloraBack.Domains.Entities.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloraBack.DataAccess.Context
{
    public class SiteReviewContext : DbContext
    {
        public DbSet<SiteReviewData> SiteReviews { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DbSession.ConnectionStrings);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserData>()
                .ToTable("Users");

            modelBuilder.Entity<UserData>()
                .HasOne(u => u.SiteReview)
                .WithOne(s => s.User)
                .HasForeignKey<SiteReviewData>(s => s.UserId)
                .OnDelete(DeleteBehavior.NoAction);
            }
    }
}
