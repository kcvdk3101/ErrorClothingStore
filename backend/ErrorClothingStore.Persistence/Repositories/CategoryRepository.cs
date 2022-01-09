using System.Linq;
using System.Threading.Tasks;
using ErrorClothingStore.Application.Contracts.Persistence;
using ErrorClothingStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ErrorClothingStore.Persistence.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Category> GetByDisplayNameAsync(string displayName)
        {
            return await DbContext.Categories.Where(p => p.DisplayName == displayName).FirstOrDefaultAsync();
        }
    }
}