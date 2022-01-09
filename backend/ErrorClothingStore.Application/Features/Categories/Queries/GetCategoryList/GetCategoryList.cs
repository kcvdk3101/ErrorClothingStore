using System.Collections.Generic;
using ErrorClothingStore.Application.Features.Categories.ViewModels;
using MediatR;

namespace ErrorClothingStore.Application.Features.Categories.Queries.GetCategoryList
{
    public class GetCategoryList : IRequest<IEnumerable<CategoryListVm>>
    {
    }
}