using LIS.API.DataTransferObjects.Categories.Request;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LIS.API.Validators.Categories
{
    public sealed class AddCategoryRequestDtoValidator: AbstractValidator<AddCategoryRequestDto>
    {
        private const string CategoryNameShouldNotBeNullOrEmptyError = "CATEGORY_NAME_SHOULDNOTBEEMPTY_ERROR";
        public AddCategoryRequestDtoValidator()
        {
            this.RuleFor(category => category.Name)
               .NotNull().WithMessage(CategoryNameShouldNotBeNullOrEmptyError)
               .NotEmpty().WithMessage(CategoryNameShouldNotBeNullOrEmptyError);
        }
    }
}
