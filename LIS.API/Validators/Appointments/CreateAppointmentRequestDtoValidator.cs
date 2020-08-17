using LIS.API.DataTransferObjects.Appointments.Request;
using LIS.Common.Extensions;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LIS.API.Validators.Appointments
{
    public sealed class CreateAppointmentRequestDtoValidator : AbstractValidator<CreateAppointmentRequestDto>
    {
        private const string AppointmentFromShouldNotBeNullOrEmptyError = "APPOINTMENT_FROM_SHOULDNOTBEEMPTY_ERROR";
        private const string AppointmentToShouldNotBeNullOrEmptyError = "APPOINTMENT_TO_SHOULDNOTBEEMPTY_ERROR";
        private const string AppointmentDoctorIdShouldNotBeNullOrEmptyError = "APPOINTMENT_DOCTOR_ID_SHOULDNOTBEEMPTY_ERROR";
        private const string AppointmentPatientTypeShouldNotBeNullOrEmptyError = "APPOINTMENT_PATIENT_TYPE_SHOULDNOTBEEMPTY_ERROR";
        private const string AppointmentFromShouldBeValidDateError = "APPOINTMENT_FROM_SHOULDBEVALIDDATE_ERROR";
        private const string AppointmentToShouldBeValidDateError = "APPOINTMENT_TO_SHOULDBEVALIDDATE_ERROR";

        public CreateAppointmentRequestDtoValidator()
        {
            this.RuleFor(appointment => appointment.From)
                .NotNull().WithMessage(AppointmentFromShouldNotBeNullOrEmptyError)
                .NotEmpty().WithMessage(AppointmentFromShouldNotBeNullOrEmptyError)
                .Must(StringExtensions.IsValidDateFormat).WithMessage(AppointmentFromShouldBeValidDateError);

            this.RuleFor(appointment => appointment.To)
                .NotNull().WithMessage(AppointmentToShouldNotBeNullOrEmptyError)
                .NotEmpty().WithMessage(AppointmentToShouldNotBeNullOrEmptyError)
                .Must(StringExtensions.IsValidDateFormat).WithMessage(AppointmentToShouldBeValidDateError);
        }
    }
}
