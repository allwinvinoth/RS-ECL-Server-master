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
    public class SavePageValidationService : ISavePageValidationService
    {
        private const string OrganisationIdShouldBeValidError = "ORGANISATION_ID_BEVALID_ERROR";

        private readonly IOrganisationRepository _organisationRepository;

        public SavePageValidationService(IOrganisationRepository organisationRepository)
        {
            _organisationRepository = organisationRepository;
        }
        public async Task Validate(PageServiceObject savePageServiceObject, CancellationToken token)
        {
            await this.ValidateIfOrganisationIdIsValid(savePageServiceObject, token);
        }

        private async Task ValidateIfOrganisationIdIsValid(PageServiceObject pageServiceObject, CancellationToken token)
        {
            try
            {
                await this._organisationRepository.GetOrganisationByIdAsync(pageServiceObject.OrganisationId, token);
            }
            catch (Exception)
            {
                var validationError = new ValidationError
                {
                    PropertyName = nameof(pageServiceObject.OrganisationId),
                    ErrorMessage = OrganisationIdShouldBeValidError
                };
                throw new BadRequestException(validationError);
            }
        }
    }
}