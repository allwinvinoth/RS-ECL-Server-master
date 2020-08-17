using LIS.ServiceContracts.ServiceObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LIS.ServiceContracts.Services
{
    public interface IPatientsService
    {
        Task<UserServiceObject> CreatePatientAsync(UserServiceObject userServiceObject, CancellationToken token);

        Task<UserServiceObject> GetPatientByIdAsync(int patientId, CancellationToken token);

        Task<IEnumerable<UserServiceObject>> SearchPatientAsync(string searchQuery, CancellationToken token);
    }
}
