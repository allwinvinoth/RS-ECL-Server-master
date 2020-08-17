using System;
using System.Threading;
using System.Threading.Tasks;
using LIS.Common.Exceptions;
using LIS.Common.Models;
using LIS.DataContracts.Repositories;
using LIS.ServiceContracts.ServiceObjects;
using LIS.ServiceContracts.Validations;

namespace LIS.Services.Validations
{
    public class SaveModuleValidationService : ISaveModuleValidationService
    {
        private const string OrganisationIdShouldBeValidError = "ORGANISATION_ID_BEVALID_ERROR";

        private readonly IOrganisationRepository _organisationRepository;

        public SaveModuleValidationService(IOrganisationRepository organisationRepository)
        {
            _organisationRepository = organisationRepository;
        }
        public async Task Validate(ModuleServiceObject saveModuleServiceObject, CancellationToken token)
        {
            await this.ValidateIfOrganisationIdIsValid(saveModuleServiceObject, token);
        }

        private async Task ValidateIfOrganisationIdIsValid(ModuleServiceObject moduleServiceObject, CancellationToken token)
        {
            try
            {
                await this._organisationRepository.GetOrganisationByIdAsync(moduleServiceObject.OrganisationId, token);
            }
            catch (Exception)
            {
                var validationError = new ValidationError
                {
                    PropertyName = nameof(moduleServiceObject.OrganisationId),
                    ErrorMessage = OrganisationIdShouldBeValidError
                };
                throw new BadRequestException(validationError);
            }
        }
    }
}