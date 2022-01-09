using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ErrorClothingStore.Application.Contracts.Persistence;
using ErrorClothingStore.Application.Features.Products.ViewModels;
using MediatR;

namespace ErrorClothingStore.Application.Features.Products.Queries.GetProductDetails
{
    public class GetProductDetailsHandler : IRequestHandler<GetProductDetails, ProductDetailsVm>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetProductDetailsHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<ProductDetailsVm> Handle(GetProductDetails request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.Id);
            return product == null ? null : _mapper.Map<ProductDetailsVm>(product);
        }
    }
}