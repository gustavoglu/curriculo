using Curriculo.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Curriculo.Infra.Data.EntityMapping
{
    public class ProductTypeMap : IEntityTypeConfiguration<ProductType>
    {
        public void Configure(EntityTypeBuilder<ProductType> b)
        {
            b.HasKey(pt => pt.Id);

            b.Property(pt => pt.Name)
                .HasMaxLength(20);

            b.HasMany(pt => pt.Products)
                .WithOne(p => p.ProductType)
                .HasForeignKey("ProductTypeId");
        }
    }
}
