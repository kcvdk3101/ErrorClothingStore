using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ErrorClothingStore.Domain.Common;

namespace ErrorClothingStore.Application.Contracts.Persistence
{
    public interface IAsyncReadRepository<T> where T : class, IAggregateRoot
    {
        Task<IEnumerable<T>> ListAsync();
        Task<T> GetByIdAsync(Guid id);
    }
}