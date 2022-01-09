using ErrorClothingStore.Domain.Entities;
using MediatR;

namespace ErrorClothingStore.Application.Features.Categories.Queries.GetCategoryByDisplayName
{
    public class GetCategoryByDisplayName : IRequest<Category>
    {
        public string DisplayName { get; init; }
    }
}