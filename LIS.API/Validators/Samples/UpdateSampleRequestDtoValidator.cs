using LIS.API.DataTransferObjects.Samples.Request;
using FluentValidation;

namespace LIS.API.Validators.Samples
{
    public class UpdateSampleRequestDtoValidator : AbstractValidator<UpdateSampleRequestDto>
    {
        private const string SampleNameShouldNotBeNullOrEmptyError = "SAMPLE_NAME_SHOULDNOTBENULLOREMPTY_ERROR";
        private const string SampleTypeShouldNotBeEmptyError = "SAMPLETYPE_SHOULDNOTBEEMPTY_ERROR";
        private const string ContainerTypeShouldNotBeEmptyError = "CONTAINERTYPE_SHOULDNOTBEEMPTY_ERROR";

        public UpdateSampleRequestDtoValidator()
        {
            this.RuleFor(sample => sample.Name)
                .NotNull().WithMessage(SampleNameShouldNotBeNullOrEmptyError)
                .NotEmpty().WithMessage(SampleNameShouldNotBeNullOrEmptyError);

            this.RuleFor(sample => sample.SampleTypeId).NotEmpty().WithMessage(SampleTypeShouldNotBeEmptyError);

            this.RuleFor(sample => sample.ContainerTypeId).NotEmpty().WithMessage(ContainerTypeShouldNotBeEmptyError);
        }
    }
}
