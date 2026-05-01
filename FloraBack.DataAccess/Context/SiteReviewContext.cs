using Microsoft.EntityFrameworkCore;
using FloraBack.Domains.Entities.SiteReview;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FloraBack.Domains.Entities.Order;
using FloraBack.Domains.Entities.User;

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

            modelBuilder.Entity<SiteReviewData>()
                .HasOne(s => s.User)
                .WithMany(u => u.SiteReviews)
                .HasForeignKey(s => s.UserId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
