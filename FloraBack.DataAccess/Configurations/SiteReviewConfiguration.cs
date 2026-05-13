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
    public class SiteReviewConfiguration : IEntityTypeConfiguration<SiteReviewData>
    {
        public void Configure(EntityTypeBuilder<SiteReviewData> builder)
        {
            builder.HasKey(s => s.Id);
        }
    }
}
