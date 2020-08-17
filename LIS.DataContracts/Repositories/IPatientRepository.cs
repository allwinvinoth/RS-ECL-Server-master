using LIS.DataContracts.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LIS.DataContracts.Repositories
{
    public interface IPatientRepository
    {
        Task<UserEntity> CreatePatientAsync(UserEntity patient, CancellationToken token);

        Task<UserEntity> GetPatientByIdAsync(int patientId, CancellationToken token);

        Task<UserEntity> GetPatientByEmailIdAsync(string email, CancellationToken token);

        Task<IEnumerable<UserEntity>> SearchPatientAsync(string searchQuery, CancellationToken token);
    }
}
