using ErrorClothingStore.Domain.Entities;

namespace ErrorClothingStore.Application.Contracts.Persistence
{
    public interface IProductRepository : IAsyncRepository<Product>, IAsyncReadRepository<Product>
    {
    }
}