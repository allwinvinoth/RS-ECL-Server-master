using LIS.API.DataTransferObjects.Pages.Request;
using FluentValidation;

namespace LIS.API.Validators.Pages
{
    public class CreatePageRequestDtoValidator : AbstractValidator<CreatePageRequestDto>
    {
        private const string PageNameShouldNotBeNullOrEmptyError = "PAGE_NAME_ SHOULDNOTBENULLOREMPTY_ERROR";
        public CreatePageRequestDtoValidator()
        {
            this.RuleFor(page => page.Name)
                .NotNull().WithMessage(PageNameShouldNotBeNullOrEmptyError)
                .NotEmpty().WithMessage(PageNameShouldNotBeNullOrEmptyError);
        }
    }
}