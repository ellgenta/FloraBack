using FloraBack.Domains.Entities.Cart;
using FloraBack.Domains.Entities.Order;
using FloraBack.Domains.Entities.ProductReview;
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
    public class UserContext : DbContext
    {
        public DbSet<UserData> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DbSession.ConnectionStrings);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*
            modelBuilder.Ignore<OrderItemData>();

            modelBuilder.Ignore<CartItemData>();

            modelBuilder.Entity<OrderData>()
                .ToTable("Orders");

            modelBuilder.Entity<CartData>()
                .ToTable("Carts");
            */

            modelBuilder.Entity<SiteReviewData>()
                .ToTable("SiteReviews");

            modelBuilder.Entity<UserData>()
                .HasOne(u => u.SiteReview)
                .WithOne(s => s.User)
                .HasForeignKey<SiteReviewData>(s => s.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            /*
            modelBuilder.Entity<UserData>()
                .HasMany(u => u.Orders)
                .WithOne(o => o.User)
                .HasForeignKey(o => o.UserId)
                .OnDelete(DeleteBehavior.NoAction);    

            modelBuilder.Entity<UserData>()
                .HasOne(u => u.Cart)
                .WithOne(c => c.User)
                .HasForeignKey<CartData>(c => c.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            */
        }
    }
}
