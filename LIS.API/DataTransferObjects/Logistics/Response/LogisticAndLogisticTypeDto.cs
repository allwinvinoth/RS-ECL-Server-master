using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LIS.API.DataTransferObjects.Logistics.Response
{
    public sealed class LogisticAndLogisticTypeDto
    {
        public LogisticTypeDto LogisticType { get; set; }
    }

    public sealed class LogisticTypeDto
    {
        public int Id { get; set; }

        public string LogisticType { get; set; }
    }
}
