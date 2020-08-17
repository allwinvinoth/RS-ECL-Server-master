using LIS.API.DataTransferObjects.ContainerTypes.Request;
using FluentValidation;

namespace LIS.API.Validators.ContainerTypes
{
    public class CreateContainerTypeRequestDtoValidator : AbstractValidator<CreateContainerTypeRequestDto>
    {
        private const string ContainerTypeNameShouldNotBeNullOrEmptyError = "CONTAINERTYPE_NAME_ SHOULDNOTBENULLOREMPTY_ERROR";
        public CreateContainerTypeRequestDtoValidator()
        {
            this.RuleFor(containerType => containerType.Name)
                .NotNull().WithMessage(ContainerTypeNameShouldNotBeNullOrEmptyError)
                .NotEmpty().WithMessage(ContainerTypeNameShouldNotBeNullOrEmptyError);
        }
    }
}
