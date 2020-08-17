using LIS.Common.Exceptions;
using LIS.Common.Models;
using LIS.DataContracts.Repositories;
using LIS.ServiceContracts.ServiceObjects;
using LIS.ServiceContracts.Validations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LIS.Services.Validations
{
    public sealed class CreatePatientValidationService : ICreatePatientValidationService
    {
        private const string PatientEmailAddressShouldBeUniqueError = "PATIENT_EMAIL_SHOULDBEUNIQUE_ERROR";

        private readonly IPatientRepository _patientRepository;

        public CreatePatientValidationService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task Validate(UserServiceObject addPatientValidationServiceObject, CancellationToken token)
        {
            await this.ValidateIfEmailAddressIsUnique(addPatientValidationServiceObject, token);
        }

        private async Task ValidateIfEmailAddressIsUnique(UserServiceObject addPatientValidationServiceObject, CancellationToken token)
        {
            var patientEntity = await _patientRepository.GetPatientByEmailIdAsync(addPatientValidationServiceObject.PrimaryEmail, token);
            if (patientEntity != null)
            {
                var validationError = new ValidationError
                {
                    ErrorMessage = PatientEmailAddressShouldBeUniqueError,
                    PropertyName = nameof(addPatientValidationServiceObject.PrimaryEmail)
                };

                throw new BadRequestException(validationError);
            }
        }
    }
}
