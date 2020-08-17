using LIS.DataContracts.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LIS.DataContracts.Repositories
{
    public interface ILogisticRepository
    {
        Task<LogisticEntity> CreateLogisticAsync(LogisticEntity logisticEntity, CancellationToken token);

        Task<LogisticEntity> UpdateLogisticByIdAsync(LogisticEntity logisticEntity, CancellationToken token);

        Task DeleteLogisticByIdAsync(int logisticId, CancellationToken token);

        Task<IEnumerable<LogisticEntity>> GetAllLogisticsAsync(CancellationToken token);

        Task<LogisticEntity> GetLogisticByIdAsync(int logisticId, CancellationToken token);
    }
}

