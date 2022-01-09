using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ErrorClothingStore.Application.Contracts.Persistence;
using ErrorClothingStore.Application.Features.Categories.ViewModels;
using ErrorClothingStore.Domain.Entities;
using FluentValidation.Results;
using MediatR;
using Slugify;

namespace ErrorClothingStore.Application.Features.Categories.Commands.CreateNewCategory
{
    public class CreateNewCategoryHandler : IRequestHandler<CreateNewCategory, (List<ValidationFailure> errors,
        CategoryDetailsVm category)>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly ISlugHelper _slugHelper;

        public CreateNewCategoryHandler(ICategoryRepository categoryRepository, IMapper mapper, ISlugHelper slugHelper)
        {
            _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _slugHelper = slugHelper ?? throw new ArgumentNullException(nameof(slugHelper));
        }

        public async Task<(List<ValidationFailure> errors, CategoryDetailsVm category)> Handle(
            CreateNewCategory request, CancellationToken cancellationToken)
        {
            var validator = new CreateNewCategoryValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid) return (validationResult.Errors, null);

            var slug = _slugHelper.GenerateSlug(request.DisplayName);
            var category = new Category(request.DisplayName, slug);

            return (null, _mapper.Map<CategoryDetailsVm>(await _categoryRepository.AddAsync(category)));
        }
    }
}