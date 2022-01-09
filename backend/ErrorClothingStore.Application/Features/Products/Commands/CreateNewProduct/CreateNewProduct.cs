using System.Collections.Generic;
using ErrorClothingStore.Application.Features.Products.ViewModels;
using ErrorClothingStore.Domain.Entities;
using FluentValidation.Results;
using MediatR;

namespace ErrorClothingStore.Application.Features.Products.Commands.CreateNewProduct
{
    public class CreateNewProduct : IRequest<(List<ValidationFailure> errors, ProductDetailsVm product)>
    {
        public string Title { get; init; }
        public decimal Price { get; init; }
        public string Description { get; init; }
        public string CategorySlug { get; init; }
        public string Image1 { get; init; }
        public string Image2 { get; init; }
        public IEnumerable<ProductSize> Sizes { get; init; }
        public IEnumerable<ProductColor> Colors { get; init; }
    }
}