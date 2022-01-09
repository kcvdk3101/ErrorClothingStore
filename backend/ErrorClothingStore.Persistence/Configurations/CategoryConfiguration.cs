using ErrorClothingStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ErrorClothingStore.Persistence.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.DisplayName).HasMaxLength(250);
            builder.Property(c => c.Slug).HasMaxLength(250);

            builder.HasIndex(c => c.DisplayName).IsUnique();
            builder.HasIndex(c => c.Slug).IsUnique();
        }
    }
}