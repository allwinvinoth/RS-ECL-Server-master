using AutoMapper;
using LIS.DataContracts.Entities;
using LIS.DataContracts.Repositories;
using LIS.ServiceContracts.ServiceObjects;
using LIS.ServiceContracts.Services;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace LIS.Services.Services
{
    public sealed class BranchService:IBranchService
    {
        private readonly IMapper _mapper;
        private readonly IBranchRepository _branchRepository;
        public BranchService(IBranchRepository branchRepository, IMapper mapper)
        {
            _branchRepository = branchRepository;
            _mapper = mapper;
        }
        public async Task<BranchServiceObject> CreateBranchAsync(BranchServiceObject branchServiceObject, CancellationToken token)
        {
            var branchEntity = _mapper.Map<BranchEntity>(branchServiceObject);
            var createdEntity = await _branchRepository.CreateBranchAsync(branchEntity, token);
            return _mapper.Map<BranchServiceObject>(createdEntity);
        }
        public async Task<IEnumerable<BranchServiceObject>> GetBranchesByOrganisationIdAsync(int organisationId, CancellationToken token)
        {
            var serviceResult = await _branchRepository.GetBranchesByOrganisationIdAsync(organisationId, token);
            return _mapper.Map<IEnumerable<BranchServiceObject>>(serviceResult);
        }
        public async Task<BranchServiceObject> UpdateBranchAsync(BranchServiceObject branchServiceObject, CancellationToken token)
        {
            var branchEntity = _mapper.Map<BranchEntity>(branchServiceObject);
            var updatedEntity = await _branchRepository.UpdateBranchAsync(branchEntity, token);
            return _mapper.Map<BranchServiceObject>(updatedEntity);
        }
        public async Task<BranchServiceObject> DeleteBranchByIdAsync(int branchId, CancellationToken token)
        {
            var serviceResult = await _branchRepository.DeleteBranchByIdAsync(branchId, token);
            return _mapper.Map<BranchServiceObject>(serviceResult);
        }
    }
}
