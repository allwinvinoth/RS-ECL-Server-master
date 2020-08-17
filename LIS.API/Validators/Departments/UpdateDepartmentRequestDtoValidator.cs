using LIS.API.DataTransferObjects.Departments.Request;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LIS.API.Validators.Departments
{
    public sealed class UpdateDepartmentRequestDtoValidator: AbstractValidator<UpdateDepartmentRequestDto>
    {
        private const string DepartmentNameShouldNotBeNullOrEmptyError = "DEPARTMENT_NAME_SHOULDNOTBEEMPTY_ERROR";
        public UpdateDepartmentRequestDtoValidator()
        {
            this.RuleFor(department => department.Name)
                .NotNull().WithMessage(DepartmentNameShouldNotBeNullOrEmptyError)
                .NotEmpty().WithMessage(DepartmentNameShouldNotBeNullOrEmptyError);
        }
    }
}
