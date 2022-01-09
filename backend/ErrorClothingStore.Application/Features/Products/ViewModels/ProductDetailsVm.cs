using System;
using System.Collections.Generic;
using ErrorClothingStore.Domain.Entities;

namespace ErrorClothingStore.Application.Features.Products.ViewModels
{
    public class ProductDetailsVm
    {
        public Guid Id { get; init; }
        public string Title { get; init; }
        public decimal Price { get; init; }
        public string Slug { get; init; }
        public string Description { get; init; }
        public string CategorySlug { get; init; }

        public string Image1 { get; init; }
        public string Image2 { get; init; }

        public IEnumerable<ProductColor> Colors { get; init; }
        public IEnumerable<ProductSize> Sizes { get; init; }
    }
}