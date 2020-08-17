using System;
using System.Threading;
using System.Threading.Tasks;
using LIS.Common.Exceptions;
using LIS.Common.Models;
using LIS.DataContracts.Repositories;
using LIS.ServiceContracts.ServiceObjects;
using LIS.ServiceContracts.Validations;

namespace LIS.Services.Validations
{
    public sealed class SaveTestValidationService : ISaveTestValidationService
    {
        private const string DepartmentIdShouldBeValidError = "DEPARTMENT_ID_BEVALID_ERROR";
        
        private const string CategoryIdShouldBeValidError = "CATEGORY_ID_BEVALID_ERROR";
        
        private readonly ICategoryRepository _categoryRepository;
        
        private readonly IDepartmentRepository _departmentRepository;

        public SaveTestValidationService(
            ICategoryRepository categoryRepository, 
            IDepartmentRepository departmentRepository)
        {
            _categoryRepository = categoryRepository;
            _departmentRepository = departmentRepository;
        }
        
        public async Task Validate(TestServiceObject saveTestServiceObject, CancellationToken token)
        {
            await this.ValidateIfDepartmentIdIsValid(saveTestServiceObject, token);
            await this.ValidateIfCategoryIdIsValid(saveTestServiceObject, token);
        }

        private async Task ValidateIfDepartmentIdIsValid(TestServiceObject testServiceObject, CancellationToken token)
        {
            try
            {
                await this._departmentRepository.GetDepartmentById(testServiceObject.DepartmentId, token);
            }
            catch (Exception)
            {
                var validationError = new ValidationError
                {
                    PropertyName = nameof(testServiceObject.DepartmentId),
                    ErrorMessage = DepartmentIdShouldBeValidError
                };
                throw new BadRequestException(validationError);
            }
        }
        
        
        private async Task ValidateIfCategoryIdIsValid(TestServiceObject testServiceObject, CancellationToken token)
        {
            try
            {
                await this._categoryRepository.GetCategoryByIdAsync(testServiceObject.CategoryId, token);
            }
            catch (Exception)
            {
                var validationError = new ValidationError
                {
                    PropertyName = nameof(testServiceObject.CategoryId),
                    ErrorMessage = CategoryIdShouldBeValidError
                };
                throw new BadRequestException(validationError);
            }
        }
    }
}