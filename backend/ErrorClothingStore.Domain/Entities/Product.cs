using System;
using System.Collections.Generic;
using ErrorClothingStore.Domain.Common;

namespace ErrorClothingStore.Domain.Entities
{
    public class Product : BaseEntity<Guid>, IAggregateRoot
    {
        public string Title { get; private set; }
        public decimal Price { get; private set; }
        public string Slug { get; private set; }
        public string Description { get; private set; }
        public string CategorySlug { get; private set; }

        public string Image1 { get; private set; }
        public string Image2 { get; private set; }

        private readonly List<ProductSize> _sizes = new();
        public IReadOnlyCollection<ProductSize> Sizes => _sizes.AsReadOnly();

        private readonly List<ProductColor> _colors = new();
        public IReadOnlyCollection<ProductColor> Colors => _colors.AsReadOnly();

        public Product(string title, decimal price, string slug, string description, string categorySlug, string image1,
            string image2)
        {
            Title = title;
            Price = price;
            Slug = slug;
            Description = description;
            CategorySlug = categorySlug;
            Image1 = image1;
            Image2 = image2;
        }

        public void AddColors(IEnumerable<ProductColor> colors)
        {
            if (colors == null) return;
            _colors.AddRange(colors);
        }

        public void AddSizes(IEnumerable<ProductSize> sizes)
        {
            if (sizes == null) return;
            _sizes.AddRange(sizes);
        }
    }
}