using FloraBack.Domains.Entities.Order;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloraBack.DataAccess.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<OrderData>
    {
        public void Configure(EntityTypeBuilder<OrderData> builder)
        {
            builder.HasKey(o => o.Id);

            builder.HasMany(o => o.Items)
                .WithOne(i => i.Order)
                .HasForeignKey(i => i.OrderId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
