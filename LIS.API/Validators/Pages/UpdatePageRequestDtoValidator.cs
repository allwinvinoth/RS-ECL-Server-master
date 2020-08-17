using FluentValidation;
using LIS.API.DataTransferObjects.Pages.Request;

namespace LIS.API.Validators.Pages
{
    public class UpdatePageRequestDtoValidator : AbstractValidator<UpdatePageRequestDto>
    {
        private const string PageNameShouldNotBeNullOrEmptyError = "PAGE_NAME_ SHOULDNOTBENULLOREMPTY_ERROR";
        public UpdatePageRequestDtoValidator()
        {
            this.RuleFor(page => page.Name)
                .NotNull().WithMessage(PageNameShouldNotBeNullOrEmptyError)
                .NotEmpty().WithMessage(PageNameShouldNotBeNullOrEmptyError);
        }
    }
}