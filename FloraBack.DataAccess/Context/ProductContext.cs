using FloraBack.Domains.Entities.Product;
using Microsoft.EntityFrameworkCore;

namespace FloraBack.DataAccess.Context
{
    public class ProductContext : DbContext
    {
        public DbSet<ProductData> Products { get; set; }
        public DbSet<ProductImgData> ProductImages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DbSession.ConnectionStrings);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductData>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<ProductData>()
                .Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(300);

            modelBuilder.Entity<ProductData>()
                .Property(p => p.SubCategory)
                .IsRequired()
                .HasMaxLength(300);

            modelBuilder.Entity<ProductData>()
                .OwnsOne(p => p.Description, description =>
                {
                    description.Property(d => d.Description)
                        .IsRequired()
                        .HasMaxLength(300);

                    description.OwnsOne(d => d.DescriptionAdvanced);
                });

            modelBuilder.Entity<ProductData>()
                .OwnsOne(p => p.Category, category =>
                {
                    category.Ignore(c => c.SubCategories);
                });

            modelBuilder.Entity<ProductData>()
                .HasMany(p => p.Images)
                .WithOne()
                .HasForeignKey(i => i.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ProductImgData>()
                .Property(i => i.Url)
                .IsRequired()
                .HasMaxLength(300);
        }
    }
}