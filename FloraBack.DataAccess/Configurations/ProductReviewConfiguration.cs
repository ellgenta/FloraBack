using FloraBack.Domains.Entities.ProductReview;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloraBack.DataAccess.Configurations
{
    public class ProductReviewConfiguration : IEntityTypeConfiguration<ProductReviewData>
    {
        public void Configure(EntityTypeBuilder<ProductReviewData> builder)
        {
            builder.HasKey(r => r.Id);

            builder.HasOne(r => r.Product)
                .WithMany(p => p.Reviews)
                .HasForeignKey(r => r.ProductId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
