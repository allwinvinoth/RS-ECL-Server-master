using LIS.ServiceContracts.ServiceObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LIS.ServiceContracts.Services
{
    public interface ICategoryService
    {
        Task<CategoryServiceObject> CreateCategoryAsync(CategoryServiceObject categoryServiceObject, CancellationToken token);

        Task<CategoryServiceObject> GetCategoryByIdAsync(long categoryId, CancellationToken token);

        Task<IEnumerable<CategoryServiceObject>> GetCategoriesAsync(CancellationToken token);

        Task<CategoryServiceObject> UpdateCategoryByIdAsync(CategoryServiceObject categoryServiceObject, CancellationToken token);

        Task DeleteCategoryByIdAsync(long categoryId, CancellationToken token);
    }
}
