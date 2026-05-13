using FloraBack.Domains.Entities.Order;
using FloraBack.Domains.Entities.SiteReview;
using FloraBack.Domains.Entities.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloraBack.DataAccess.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<UserData>
    {
        public void Configure(EntityTypeBuilder<UserData> builder)
        {
            builder.HasKey(u => u.Id);

            builder.HasOne(u => u.SiteReview)
                .WithOne(s => s.User)
                .HasForeignKey<SiteReviewData>(s => s.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(u => u.Orders)
                .WithOne(o => o.User)
                .HasForeignKey(o => o.UserId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
