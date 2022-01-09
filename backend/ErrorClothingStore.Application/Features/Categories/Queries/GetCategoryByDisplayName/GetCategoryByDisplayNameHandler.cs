using System;
using System.Threading;
using System.Threading.Tasks;
using ErrorClothingStore.Application.Contracts.Persistence;
using ErrorClothingStore.Domain.Entities;
using MediatR;

namespace ErrorClothingStore.Application.Features.Categories.Queries.GetCategoryByDisplayName
{
    public class GetCategoryByDisplayNameHandler : IRequestHandler<GetCategoryByDisplayName, Category>
    {
        private readonly ICategoryRepository _categoryRepository;

        public GetCategoryByDisplayNameHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
        }

        public async Task<Category> Handle(GetCategoryByDisplayName request, CancellationToken cancellationToken)
        {
            return await _categoryRepository.GetByDisplayNameAsync(request.DisplayName);
        }
    }
}