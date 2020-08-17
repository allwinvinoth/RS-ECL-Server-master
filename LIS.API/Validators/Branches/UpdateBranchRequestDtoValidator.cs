using LIS.API.DataTransferObjects.Branches.Request;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LIS.API.Validators.Branches
{
    public sealed class UpdateBranchRequestDtoValidator:AbstractValidator<UpdateBranchRequestDto>
    {
        private const string BranchNameShouldNotBeNullOrEmptyError = "BRANCH_NAME_SHOULDNOTBEEMPTY_ERROR";
        public UpdateBranchRequestDtoValidator()
        {
            this.RuleFor(branch=> branch.Name)
                .NotNull().WithMessage(BranchNameShouldNotBeNullOrEmptyError)
                .NotEmpty().WithMessage(BranchNameShouldNotBeNullOrEmptyError);
        }
    }
}
