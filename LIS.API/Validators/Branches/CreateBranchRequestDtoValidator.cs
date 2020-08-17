using LIS.API.DataTransferObjects.Branches.Request;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LIS.API.Validators.Branches
{
    public sealed class CreateBranchRequestDtoValidator : AbstractValidator<CreateBranchRequestDto>
    {
        private const string BranchNameShouldNotBeNullOrEmptyError = "BRANCH_NAME_SHOULDNOTBEEMPTY_ERROR";
        public CreateBranchRequestDtoValidator()
        {
            this.RuleFor(branch => branch.Name)
                .NotNull().WithMessage(BranchNameShouldNotBeNullOrEmptyError)
                .NotEmpty().WithMessage(BranchNameShouldNotBeNullOrEmptyError);
        }
    }
}
