using System;
using ErrorClothingStore.Application.Features.Products.ViewModels;
using MediatR;

namespace ErrorClothingStore.Application.Features.Products.Queries.GetProductDetails
{
    public class GetProductDetails : IRequest<ProductDetailsVm>
    {
        public Guid Id { get; init; }
    }
}