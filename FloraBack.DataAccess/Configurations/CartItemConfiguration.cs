using FloraBack.Domains.Entities.Cart;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloraBack.DataAccess.Configurations
{
    public class CartItemConfiguration : IEntityTypeConfiguration<CartItemData>
    {
        public void Configure(EntityTypeBuilder<CartItemData> builder)
        {
            builder.HasKey(i => i.Id);

            builder.HasOne(i => i.Product)
                .WithMany(p => p.CartItems)
                .HasForeignKey(i => i.ProductId);
        }
    }
}
