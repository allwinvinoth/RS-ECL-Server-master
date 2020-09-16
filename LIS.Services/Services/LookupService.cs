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
    public sealed class LookupService : ILookupService
    {
        private readonly IMapper _mapper;
        private readonly ILookupRepository _lookupRepository;
        public LookupService(ILookupRepository lookupRepository, IMapper mapper)
        {
            _lookupRepository = lookupRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<LookupServiceObject>> GetAll(string param, CancellationToken token)
        {
            var serviceResult = await _lookupRepository.GetAll(param, token);
            return _mapper.Map<IEnumerable<LookupServiceObject>>(serviceResult);
        }
    }
}
