using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ErrorClothingStore.Application.Contracts.Persistence;
using ErrorClothingStore.Application.Features.Products.ViewModels;
using MediatR;

namespace ErrorClothingStore.Application.Features.Products.Queries.GetProductList
{
    public class GetProductListHandler : IRequestHandler<GetProductList, IEnumerable<ProductListVm>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetProductListHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<ProductListVm>> Handle(GetProductList request,
            CancellationToken cancellationToken)
        {
            // TODO: get product list by category

            var productList = await _productRepository.ListAsync();

            return _mapper.Map<IEnumerable<ProductListVm>>(productList);
        }
    }
}