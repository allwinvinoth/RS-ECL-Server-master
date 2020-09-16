using LIS.ServiceContracts.ServiceObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LIS.ServiceContracts.Services
{
    public interface ILookupService
    {

        Task<IEnumerable<LookupServiceObject>> GetAll(string param, CancellationToken token);

    }
}
