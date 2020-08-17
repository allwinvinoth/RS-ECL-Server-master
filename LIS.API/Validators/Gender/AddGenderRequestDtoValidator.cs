using LIS.API.DataTransferObjects.Gender.Request;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LIS.API.Validators.Gender
{
    public sealed class AddGenderRequestDtoValidator: AbstractValidator<AddGenderRequestDto>
    {
        private const string GenderNameShouldNotBeNullOrEmptyError = "GENDER_NAME_SHOULDNOTBEEMPTY_ERROR";
        public AddGenderRequestDtoValidator()
        {
            this.RuleFor(gender => gender.Name)
               .NotNull().WithMessage(GenderNameShouldNotBeNullOrEmptyError)
               .NotEmpty().WithMessage(GenderNameShouldNotBeNullOrEmptyError);
        }
    }
}
