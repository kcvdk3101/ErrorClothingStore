using ErrorClothingStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ErrorClothingStore.Persistence.Configurations
{
    public class ProductSizeConfiguration : IEntityTypeConfiguration<ProductSize>
    {
        public void Configure(EntityTypeBuilder<ProductSize> builder)
        {
            builder.HasKey(ps => ps.Id);
            builder.Property(ps => ps.Display).HasMaxLength(250);
            builder.Property(ps => ps.Size).HasMaxLength(250);
        }
    }
}