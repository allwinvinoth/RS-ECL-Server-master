using LIS.API.DataTransferObjects.Modules.Request;
using FluentValidation;

namespace LIS.API.Validators.Modules
{
    public class UpdateModuleRequestDtoValidator : AbstractValidator<UpdateModuleRequestDto>
    {
        private const string ModuleNameShouldNotBeNullOrEmptyError = "MODULE_NAME_SHOULDNOTBEEMPTY_ERROR";
        public UpdateModuleRequestDtoValidator()
        {
            this.RuleFor(module => module.Name)
                .NotNull().WithMessage(ModuleNameShouldNotBeNullOrEmptyError)
                .NotEmpty().WithMessage(ModuleNameShouldNotBeNullOrEmptyError);
        }
    }
}