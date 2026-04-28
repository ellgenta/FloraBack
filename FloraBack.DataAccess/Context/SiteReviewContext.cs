using Microsoft.EntityFrameworkCore;
using FloraBack.Domains.Entities.SiteReview;
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
    }
}
