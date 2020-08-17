using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LIS.API.DataTransferObjects.Departments.Request;
using FluentValidation;

namespace LIS.API.Validators.Departments
{
    public sealed class CreateDepartmentRequestDtoValidator: AbstractValidator<CreateDepartmentRequestDto>
    {
        private const string DepartmentNameShouldNotBeNullOrEmptyError = "DEPARTMENT_NAME_SHOULDNOTBEEMPTY_ERROR";
        public CreateDepartmentRequestDtoValidator()
        {
            this.RuleFor(department => department.Name)
                .NotNull().WithMessage(DepartmentNameShouldNotBeNullOrEmptyError)
                .NotEmpty().WithMessage(DepartmentNameShouldNotBeNullOrEmptyError);
        }
    }
}
