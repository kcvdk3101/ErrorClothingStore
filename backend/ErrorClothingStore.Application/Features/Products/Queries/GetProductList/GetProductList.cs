using System.Collections.Generic;
using ErrorClothingStore.Application.Features.Products.ViewModels;
using MediatR;

namespace ErrorClothingStore.Application.Features.Products.Queries.GetProductList
{
    public class GetProductList : IRequest<IEnumerable<ProductListVm>>
    {
    }
}