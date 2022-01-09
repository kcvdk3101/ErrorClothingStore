using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ErrorClothingStore.Application.Contracts.Persistence;
using ErrorClothingStore.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace ErrorClothingStore.Persistence.Repositories
{
    public class BaseRepository<T> : IAsyncReadRepository<T>, IAsyncRepository<T> where T : class, IAggregateRoot
    {
        protected ApplicationDbContext DbContext { get; }

        public BaseRepository(ApplicationDbContext dbContext)
        {
            DbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public virtual async Task<IEnumerable<T>> ListAsync()
        {
            return await DbContext.Set<T>().ToListAsync();
        }

        public virtual async Task<T> GetByIdAsync(Guid id)
        {
            return await DbContext.Set<T>().FindAsync(id);
        }

        public async Task<T> AddAsync(T entity)
        {
            var inserted = DbContext.Add(entity).Entity;
            await DbContext.SaveChangesAsync();
            return inserted;
        }
    }
}