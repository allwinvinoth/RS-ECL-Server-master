using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using LIS.DataContracts.Entities;

namespace LIS.DataContracts.Repositories
{
    public interface ILookupRepository
    {
        Task<IEnumerable<LookupEntity>> GetAll(string param, CancellationToken token);
    }
}