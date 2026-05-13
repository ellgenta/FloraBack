using FloraBack.Domains.Entities.Product;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloraBack.DataAccess.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<ProductData>
    {
        public void Configure(EntityTypeBuilder<ProductData> builder)
        {
            builder.HasKey(p => p.Id);

            builder.HasOne(p => p.Description)
                .WithOne(d => d.Product)
                .HasForeignKey<ProductDescriptionData>(d => d.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(p => p.Images)
                .WithOne(i => i.Product)
                .HasForeignKey(i => i.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
