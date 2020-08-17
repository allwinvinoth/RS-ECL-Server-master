using LIS.API.DataTransferObjects.Tests.Request;
using FluentValidation;

namespace LIS.API.Validators.Tests
{
    public sealed class AddTestRequestDtoValidator : AbstractValidator<AddTestRequestDto>
    {
        private const string TestNameShouldNotBeNullOrEmptyError = "TEST_NAME_SHOULDNOTBEEMPTY_ERROR";
        
        private const string TestCostShouldNotBeNullOrEmptyError = "TEST_COST_SHOULDNOTBEEMPTY_ERROR";
        
        private const string TestCategoryShouldNotBeNullOrEmptyError = "TEST_CATEGORY_SHOULDNOTBEEMPTY_ERROR";

        private const string TestDepartmentShouldNotBeNullOrEmptyError = "TEST_DEPARTMENT_SHOULDNOTBEEMPTY_ERROR";
        
        private const string TestTATMinutesShouldNotBeNullOrEmptyError = "TEST_TATMINUTES_SHOULDNOTBEEMPTY_ERROR";
        
        private const string TestTATDaysShouldNotBeNullOrEmptyError = "TEST_TATDAYS_SHOULDNOTBEEMPTY_ERROR";
        
        private const string TestTATHoursShouldNotBeNullOrEmptyError = "TEST_TATHOURS_SHOULDNOTBEEMPTY_ERROR";

        public AddTestRequestDtoValidator()
        {
            this.RuleFor(test => test.Name)
                .NotNull().WithMessage(TestNameShouldNotBeNullOrEmptyError)
                .NotEmpty().WithMessage(TestNameShouldNotBeNullOrEmptyError);

            this.RuleFor(test => test.Cost)
                .NotNull().WithMessage(TestCostShouldNotBeNullOrEmptyError)
                .NotEmpty().WithMessage(TestCostShouldNotBeNullOrEmptyError);

            this.RuleFor(test => test.CategoryId)
                .NotNull().WithMessage(TestCategoryShouldNotBeNullOrEmptyError)
                .NotEmpty().WithMessage(TestCategoryShouldNotBeNullOrEmptyError);

            this.RuleFor(test => test.DepartmentId)
                .NotNull().WithMessage(TestDepartmentShouldNotBeNullOrEmptyError)
                .NotEmpty().WithMessage(TestDepartmentShouldNotBeNullOrEmptyError);

            this.RuleFor(test => test.TargetTATMinutes)
                .NotNull().WithMessage(TestTATMinutesShouldNotBeNullOrEmptyError)
                .NotEmpty().WithMessage(TestTATMinutesShouldNotBeNullOrEmptyError);

            this.RuleFor(test => test.TargetTATDays)
                .NotNull().WithMessage(TestTATDaysShouldNotBeNullOrEmptyError)
                .NotEmpty().WithMessage(TestTATDaysShouldNotBeNullOrEmptyError);

            this.RuleFor(test => test.TargetTATHours)
                .NotNull().WithMessage(TestTATHoursShouldNotBeNullOrEmptyError)
                .NotEmpty().WithMessage(TestTATHoursShouldNotBeNullOrEmptyError);
        }
    }
}