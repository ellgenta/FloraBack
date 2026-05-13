using FloraBack.Domains.Entities.Order;
using FloraBack.Domains.Entities.User;
using FloraBack.Domains.Entities.SiteReview;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloraBack.DataAccess.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<UserData> Users { get; set; }

        public DbSet<SiteReviewData> SiteReviews { get; set; }

        public DbSet<OrderData> Orders { get; set; }

        public DbSet<OrderItemData> OrderItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DbSession.ConnectionStrings);
        }
    }
}
