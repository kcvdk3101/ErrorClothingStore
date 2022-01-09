using System.Threading.Tasks;
using ErrorClothingStore.Domain.Entities;

namespace ErrorClothingStore.Application.Contracts.Persistence
{
    public interface ICategoryRepository : IAsyncReadRepository<Category>, IAsyncRepository<Category>
    {
        Task<Category> GetByDisplayNameAsync(string displayName);
    }
}