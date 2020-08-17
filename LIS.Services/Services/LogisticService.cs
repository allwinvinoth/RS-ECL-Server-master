using AutoMapper;
using LIS.DataContracts.Entities;
using LIS.DataContracts.Repositories;
using LIS.ServiceContracts.ServiceObjects;
using LIS.ServiceContracts.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LIS.Services.Services
{
    public class LogisticService : ILogisticService
    {
        private readonly IMapper _mapper;
        private readonly ILogisticRepository _logisticRepository;

        public LogisticService(ILogisticRepository logisticRepository, IMapper mapper)
        {
            _logisticRepository = logisticRepository;
            _mapper = mapper;
        }

        public async Task<LogisticAndServiceObject> CreateLogisticAsync(LogisticAndServiceObject logisticServiceObject, CancellationToken token)
        {
            var logisticEntity = this._mapper.Map<LogisticEntity>(logisticServiceObject);
            var createdEntity = await _logisticRepository.CreateLogisticAsync(logisticEntity, token);
            return this._mapper.Map<LogisticAndServiceObject>(createdEntity);
        }

        public async Task<LogisticAndServiceObject> UpdateLogisticByIdAsync(LogisticAndServiceObject logisticServiceObject, CancellationToken token)
        {
            var logisticEntity = this._mapper.Map<LogisticEntity>(logisticServiceObject);
            var updatedEntity = await _logisticRepository.UpdateLogisticByIdAsync(logisticEntity, token);
            return this._mapper.Map<LogisticAndServiceObject>(updatedEntity);
        }

        public async Task DeleteLogisticByIdAsync(int logisticId, CancellationToken token)
        {
            await _logisticRepository.DeleteLogisticByIdAsync(logisticId, token);
        }

        public async Task<IEnumerable<LogisticAndServiceObject>> GetAllLogisticsAsync(CancellationToken token)
        {
            var serviceResult = await _logisticRepository.GetAllLogisticsAsync(token);
            return this._mapper.Map<IEnumerable<LogisticAndServiceObject>>(serviceResult);
        }

        public async Task<LogisticAndServiceObject> GetLogisticByIdAsync(int logisticId, CancellationToken token)
        {
            var logisticEntity = await _logisticRepository.GetLogisticByIdAsync(logisticId, token);
            return this._mapper.Map<LogisticAndServiceObject>(logisticEntity);
        }
    }
}
