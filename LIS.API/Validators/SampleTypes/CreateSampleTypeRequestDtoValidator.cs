using LIS.API.DataTransferObjects.SampleTypes.Request;
using FluentValidation;

namespace LIS.API.Validators.SampleTypes
{
    public class CreateSampleTypeRequestDtoValidator : AbstractValidator<CreateSampleTypeRequestDto>
    {
        private const string SampleTypeNameShouldNotBeNullOrEmptyError = "SAMPLETYPE_NAME_SHOULDNOTBENULLOREMPTY_ERROR";
        public CreateSampleTypeRequestDtoValidator()
        {
            this.RuleFor(sampleType => sampleType.Name)
                .NotNull().WithMessage(SampleTypeNameShouldNotBeNullOrEmptyError)
                .NotEmpty().WithMessage(SampleTypeNameShouldNotBeNullOrEmptyError);
        }
    }
}
