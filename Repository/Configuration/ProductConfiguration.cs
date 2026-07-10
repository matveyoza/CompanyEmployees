using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Name).IsRequired().HasMaxLength(60);
            builder.Property(p => p.Price).HasColumnType("decimal(18,2)").IsRequired();

            builder.HasData(
                new Product
                {
                    Id = new Guid("11111111-1111-1111-1111-111111111111"),
                    Name = "iPhone 15",
                    Price = 999.99m,
                    CompanyId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870")
                }
            );
        }
    }
}
