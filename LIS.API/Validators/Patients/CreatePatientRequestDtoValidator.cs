using LIS.API.DataTransferObjects.Patients.Request;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LIS.API.Validators.Patients
{
    public sealed class CreatePatientRequestDtoValidator : AbstractValidator<CreatePatientRequestDto>
    {
        private const string PatientNameShouldNotBeNullOrEmptyError = "PATIENT_NAME_SHOULDNOTBEEMPTY_ERROR";
        private const string PatientPrimaryContactNumberShouldNotBeNullOrEmptyError = "PATIENT_PRIMARYCONTACTNUMBER_SHOULDNOTBEEMPTY_ERROR";
        private const string PatientPrimaryEmailShouldBeValidFormatError = "PATIENT_PRIMARYCONTACTNUMBER_SHOULDNOTBEEMPTY_ERROR";
        private const string PatientPrimaryEmailShouldNotBeNullOrEmptyError = "PATIENT_EMAIL_SHOULDNOTBEEMPTY_ERROR";
        private const string PatientGenderShouldNotBeNullOrEmptyError = "PATIENT_GENDER_SHOULDNOTBEEMPTY_ERROR";

        public CreatePatientRequestDtoValidator()
        {
            this.RuleFor(patient => patient.Name)
                .NotNull().WithMessage(PatientNameShouldNotBeNullOrEmptyError)
                .NotEmpty().WithMessage(PatientNameShouldNotBeNullOrEmptyError);

            this.RuleFor(patient => patient.PrimaryEmail)
                .NotNull().WithMessage(PatientPrimaryEmailShouldNotBeNullOrEmptyError)
                .NotEmpty().WithMessage(PatientPrimaryEmailShouldNotBeNullOrEmptyError)
                .EmailAddress().WithMessage(PatientPrimaryEmailShouldBeValidFormatError);

            this.RuleFor(patient => patient.PrimaryContactNumber)
                .NotNull().WithMessage(PatientPrimaryContactNumberShouldNotBeNullOrEmptyError)
                .NotEmpty().WithMessage(PatientPrimaryContactNumberShouldNotBeNullOrEmptyError);

            this.RuleFor(patient => patient.GenderId)
                .NotNull().WithMessage(PatientGenderShouldNotBeNullOrEmptyError)
                .NotEmpty().WithMessage(PatientGenderShouldNotBeNullOrEmptyError);
        }
    }
}
