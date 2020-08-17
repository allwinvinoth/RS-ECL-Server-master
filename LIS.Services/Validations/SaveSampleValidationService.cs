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
    public class SaveSampleValidationService : ISaveSampleValidationService
    {
        private const string SampleTypeIdInvalidError = "SAMPLE_TYPE_ID_INVALID_ERROR";
        private const string ContainerTypeIdInvalidError = "CONTAINER_TYPE_ID_INVALID_ERROR";

        private readonly ISampleTypeRepository _sampleTypeRepository;
        private readonly IContainerTypeRepository _containerTypeRepository;

        public SaveSampleValidationService(ISampleTypeRepository sampleTypeRepository, IContainerTypeRepository containerTypeRepository)
        {
            _sampleTypeRepository = sampleTypeRepository;
            _containerTypeRepository = containerTypeRepository;
        }

        public async Task Validate(SampleServiceObject saveSampleServiceObject, CancellationToken token)
        {
            await this.ValidateIfSampleTypeIdIsValid(saveSampleServiceObject, token);
            await this.ValidateIfContainerTypeIdIsValid(saveSampleServiceObject, token);
        }
        
        private async Task ValidateIfSampleTypeIdIsValid(SampleServiceObject sampleServiceObject, CancellationToken token)
        {
            try
            {
                await this._sampleTypeRepository.GetSampleTypeEntityByIdAsync(sampleServiceObject.SampleTypeId, token);
            }
            catch (Exception)
            {
                var validationError = new ValidationError
                {
                    PropertyName = nameof(sampleServiceObject.SampleTypeId),
                    ErrorMessage = SampleTypeIdInvalidError
                };
                throw new BadRequestException(validationError);
            }
        }

        private async Task ValidateIfContainerTypeIdIsValid(SampleServiceObject saveSampleServiceObject, CancellationToken token)
        {
            try
            {
                await this._containerTypeRepository.GetContainerTypeByIdAsync(saveSampleServiceObject.ContainerTypeId, token);
            }
            catch (Exception)
            {
                var validationError = new ValidationError
                {
                    PropertyName = nameof(saveSampleServiceObject.ContainerTypeId),
                    ErrorMessage = ContainerTypeIdInvalidError
                };
                throw new BadRequestException(validationError);
            }
        }

    }
}
