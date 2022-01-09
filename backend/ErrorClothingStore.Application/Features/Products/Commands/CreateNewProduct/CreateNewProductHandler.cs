using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ErrorClothingStore.Application.Contracts.Persistence;
using ErrorClothingStore.Application.Features.Products.ViewModels;
using ErrorClothingStore.Domain.Entities;
using FluentValidation.Results;
using MediatR;
using Slugify;

namespace ErrorClothingStore.Application.Features.Products.Commands.CreateNewProduct
{
    public class CreateNewProductHandler : IRequestHandler<CreateNewProduct, (List<ValidationFailure> errors,
        ProductDetailsVm product)>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly ISlugHelper _slugHelper;

        public CreateNewProductHandler(IProductRepository productRepository, IMapper mapper, ISlugHelper slugHelper)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _slugHelper = slugHelper ?? throw new ArgumentNullException(nameof(slugHelper));
        }

        public async Task<(List<ValidationFailure> errors, ProductDetailsVm product)> Handle(CreateNewProduct request,
            CancellationToken cancellationToken)
        {
            var validator = new CreateNewProductValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid) return (validationResult.Errors, null);

            var slug = _slugHelper.GenerateSlug(request.Title);
            var product = new Product(request.Title, request.Price, slug, request.Description, request.CategorySlug,
                request.Image1, request.Image2);

            product.AddColors(request.Colors);
            product.AddSizes(request.Sizes);

            return (null, _mapper.Map<ProductDetailsVm>(await _productRepository.AddAsync(product)));
        }
    }
}