using Curriculo.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Curriculo.Infra.Data.EntityMapping
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> b)
        {
            b.HasKey(p => p.Id);

            b.Property(p => p.Name)
                .HasMaxLength(20);

            b.Property(p => p.Description)
                .HasMaxLength(100);

            b.HasOne(p => p.ProductType)
                .WithMany(pt => pt.Products)
                .HasForeignKey(p => p.ProductTypeId)
                .IsRequired();
        }
    }
}
