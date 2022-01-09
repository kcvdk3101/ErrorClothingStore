using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ErrorClothingStore.Application.Contracts.Persistence;
using ErrorClothingStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ErrorClothingStore.Persistence.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task<IEnumerable<Product>> ListAsync()
        {
            return await DbContext.Products
                .Include(p => p.Colors)
                .Include(p => p.Sizes)
                .AsSplitQuery()
                .OrderByDescending(p => p.Title).ToListAsync();
        }

        public override async Task<Product> GetByIdAsync(Guid id)
        {
            return await DbContext.Products.Where(p => p.Id == id)
                .Include(p => p.Colors)
                .Include(p => p.Sizes)
                .AsSplitQuery()
                .FirstOrDefaultAsync();
        }
    }
}