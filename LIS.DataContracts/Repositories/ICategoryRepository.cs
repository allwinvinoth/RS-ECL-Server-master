using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using LIS.DataContracts.Entities;

namespace LIS.DataContracts.Repositories
{
    public interface ICategoryRepository
    {
        Task<CategoryEntity> GetCategoryByIdAsync(long id, CancellationToken token);

        Task<CategoryEntity> CreateCategoryAsync(CategoryEntity categoryEntity, CancellationToken token);

        Task<IEnumerable<CategoryEntity>> GetCategoriesAsync(CancellationToken token);

        Task<CategoryEntity> UpdateCategoryByIdAsync(CategoryEntity categoryEntity, CancellationToken token);

        Task DeleteCategoryByIdAsync(long categoryId, CancellationToken token);
    }
}