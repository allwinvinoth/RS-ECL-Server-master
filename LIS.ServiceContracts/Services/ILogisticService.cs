using LIS.ServiceContracts.ServiceObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LIS.ServiceContracts.Services
{
    public interface ILogisticService
    {
        Task<LogisticAndServiceObject> CreateLogisticAsync(LogisticAndServiceObject logisticServiceObject, CancellationToken token);

        Task<LogisticAndServiceObject> UpdateLogisticByIdAsync(LogisticAndServiceObject logisticServiceObject, CancellationToken token);

        Task DeleteLogisticByIdAsync(int logisticId, CancellationToken token);

        Task<IEnumerable<LogisticAndServiceObject>> GetAllLogisticsAsync(CancellationToken token);

        Task<LogisticAndServiceObject> GetLogisticByIdAsync(int logisticId, CancellationToken token);
    }
}
