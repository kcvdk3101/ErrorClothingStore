using ErrorClothingStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ErrorClothingStore.Persistence.Configurations
{
    public class ProductColorConfiguration : IEntityTypeConfiguration<ProductColor>
    {
        public void Configure(EntityTypeBuilder<ProductColor> builder)
        {
            builder.HasKey(pc => pc.Id);
            builder.Property(pc => pc.Display).HasMaxLength(250);
            builder.Property(pc => pc.Color).HasMaxLength(250);
        }
    }
}