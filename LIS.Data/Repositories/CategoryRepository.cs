using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using LIS.DataContracts.Entities;
using LIS.DataContracts.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LIS.Data.Repositories
{
    public sealed class CategoryRepository : ICategoryRepository
    {
        private readonly LISDbContext _dbContext;

        public CategoryRepository(LISDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task<CategoryEntity> GetCategoryByIdAsync(long id, CancellationToken token)
        {
            return await _dbContext.Categories
                                   .SingleAsync(category => category.Id == id && category.IsActive, token);
        }

        public async Task<CategoryEntity> CreateCategoryAsync(CategoryEntity categoryEntity, CancellationToken token)
        {
            await _dbContext.Categories.AddAsync(categoryEntity, token);
            await _dbContext.SaveChangesAsync(token);
            return categoryEntity;
        }

        public async Task<IEnumerable<CategoryEntity>> GetCategoriesAsync(CancellationToken token)
        {
            return await _dbContext.Categories
                                   .Where(category => category.IsActive).ToListAsync(token);
        }

        public async Task<CategoryEntity> UpdateCategoryByIdAsync(CategoryEntity categoryEntity, CancellationToken token)
        {
            _dbContext.Categories.Update(categoryEntity);
            await _dbContext.SaveChangesAsync(token);
            return categoryEntity;
        }

        public async Task DeleteCategoryByIdAsync(long categoryId, CancellationToken token)
        {
            var categoryEntity = await _dbContext.Categories.SingleAsync(category => category.Id == categoryId, token);
            categoryEntity.IsActive = false;
            await _dbContext.SaveChangesAsync(token);
        }
    }
}