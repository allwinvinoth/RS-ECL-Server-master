using LIS.ServiceContracts.ServiceObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LIS.ServiceContracts.Services
{
    public interface IIndividualTestMasterService
    {
        Task<IndividualTestServiceObject> CreateIndividualTestMasterAsync(IndividualTestServiceObject departmentServiceObject, CancellationToken token);

        Task<IEnumerable<IndividualTestServiceObject>> GetAll(CancellationToken token);

        Task<IndividualTestServiceObject> UpdateIndividualTestMasterAsync(IndividualTestServiceObject departmentServiceObject, CancellationToken token);

        Task DeleteIndividualTestMasterByIdAsync(int departmentId, CancellationToken token);
    }
}
