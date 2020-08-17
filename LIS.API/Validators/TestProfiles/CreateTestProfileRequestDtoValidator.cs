using LIS.API.DataTransferObjects.TestProfiles.Request;
using FluentValidation;

namespace LIS.API.Validators.TestProfiles
{
    public class CreateTestProfileRequestDtoValidator : AbstractValidator<CreateTestProfileRequestDto>
    {
        private const string TestProfileNameShouldNotBeNullOrEmptyError = "TEST_PROFILE_NAME_SHOULDNOTBEEMPTY_ERROR";

        public CreateTestProfileRequestDtoValidator()
        {
            this.RuleFor(testProfile => testProfile.Name)
                .NotNull().WithMessage(TestProfileNameShouldNotBeNullOrEmptyError)
                .NotEmpty().WithMessage(TestProfileNameShouldNotBeNullOrEmptyError);
        }
    }
}