using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ErrorClothingStore.Application.Contracts.Persistence;
using ErrorClothingStore.Application.Features.Categories.ViewModels;
using MediatR;

namespace ErrorClothingStore.Application.Features.Categories.Queries.GetCategoryList
{
    public class GetCategoryListHandler : IRequestHandler<GetCategoryList, IEnumerable<CategoryListVm>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetCategoryListHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<CategoryListVm>> Handle(GetCategoryList request,
            CancellationToken cancellationToken)
        {
            var categoryList = await _categoryRepository.ListAsync();
            return _mapper.Map<IEnumerable<CategoryListVm>>(categoryList);
        }
    }
}