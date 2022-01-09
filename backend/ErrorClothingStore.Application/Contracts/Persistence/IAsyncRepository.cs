using System.Threading.Tasks;
using ErrorClothingStore.Domain.Common;

namespace ErrorClothingStore.Application.Contracts.Persistence
{
    public interface IAsyncRepository<T> where T : class, IAggregateRoot
    {
        Task<T> AddAsync(T entity);
    }
}