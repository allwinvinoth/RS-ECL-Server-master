using AutoMapper;
using LIS.DataContracts.Entities;
using LIS.DataContracts.Repositories;
using LIS.ServiceContracts.ServiceObjects;
using LIS.ServiceContracts.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LIS.Services.Services
{
    public sealed class CategoryService:ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        private readonly IMapper _mapper;
        public CategoryService(
           ICategoryRepository categoryRepository,
           IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public async Task<CategoryServiceObject> CreateCategoryAsync(CategoryServiceObject categoryServiceObject, CancellationToken token)
        {
            var categoryEntity = _mapper.Map<CategoryEntity>(categoryServiceObject);
            var createdEntity = await _categoryRepository.CreateCategoryAsync(categoryEntity, token);
            return _mapper.Map<CategoryServiceObject>(createdEntity);
        }
        public async Task<CategoryServiceObject> GetCategoryByIdAsync(long categoryId, CancellationToken token)
        {
            var categoryEntity = await _categoryRepository.GetCategoryByIdAsync(categoryId, token);
            return _mapper.Map<CategoryServiceObject>(categoryEntity);
        }
        public async Task<IEnumerable<CategoryServiceObject>> GetCategoriesAsync(CancellationToken token)
        {
            var serviceResult = await _categoryRepository.GetCategoriesAsync(token);
            return _mapper.Map<IEnumerable<CategoryServiceObject>>(serviceResult);
        }
        public async Task<CategoryServiceObject> UpdateCategoryByIdAsync(CategoryServiceObject categoryServiceObject, CancellationToken token)
        {
            var categoryEntity = _mapper.Map<CategoryEntity>(categoryServiceObject);
            var updatedEntity = await _categoryRepository.UpdateCategoryByIdAsync(categoryEntity, token);
            return _mapper.Map<CategoryServiceObject>(updatedEntity);
        }
        public async Task DeleteCategoryByIdAsync(long categoryId, CancellationToken token)
        {
            await _categoryRepository.DeleteCategoryByIdAsync(categoryId, token);
        }
    }
}
