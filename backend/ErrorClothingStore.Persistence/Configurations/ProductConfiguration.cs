using ErrorClothingStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ErrorClothingStore.Persistence.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Title).HasMaxLength(250);
            builder.Property(p => p.Slug).HasMaxLength(250);
            builder.Property(p => p.Price).HasColumnType("decimal(17, 2)");

            builder.HasMany(p => p.Sizes);
            builder.HasMany(p => p.Colors);
        }
    }
}