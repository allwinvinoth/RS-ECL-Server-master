using LIS.ServiceContracts.ServiceObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LIS.ServiceContracts.Services
{
    public interface IGenderService
    {
        Task<GenderServiceObject> CreateGenderAsync(GenderServiceObject genderServiceObject, CancellationToken token);

        Task<GenderServiceObject> GetGenderByIdAsync(int genderId, CancellationToken token);

        Task<IEnumerable<GenderServiceObject>> GetGenderListAsync(CancellationToken token);

        Task<GenderServiceObject> UpdateGenderByIdAsync(GenderServiceObject genderServiceObject, CancellationToken token);

        Task DeleteGenderByIdAsync(int genderId, CancellationToken token);
    }
}
