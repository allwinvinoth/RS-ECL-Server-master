using LIS.API.DataTransferObjects.Organisations.Request;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LIS.API.Validators.Organisations
{
    public sealed class UpdateOrganisationRequestDtoValidator: AbstractValidator<UpdateOrganisationRequestDto>
    {
        private const string OrganisationNameShouldNotBeNullOrEmptyError = "ORGANISATION_NAME_SHOULDNOTBEEMPTY_ERROR";
        public UpdateOrganisationRequestDtoValidator()
        {
            this.RuleFor(organisation => organisation.Name)
                .NotNull().WithMessage(OrganisationNameShouldNotBeNullOrEmptyError)
                .NotEmpty().WithMessage(OrganisationNameShouldNotBeNullOrEmptyError);
        }
    }
}
