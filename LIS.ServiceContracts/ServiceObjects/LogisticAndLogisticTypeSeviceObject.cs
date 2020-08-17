using System;
using System.Collections.Generic;
using System.Text;

namespace LIS.ServiceContracts.ServiceObjects
{
    public sealed class LogisticAndLogisticTypeSeviceObject
    {
        public int Id { get; set; }

        public int LogisticId { get; set; }

        public int LogisticTypeId { get; set; }

        public LogisticAndServiceObject Logistic { get; set; }

        public LogisticTypeServiceObject LogisticType { get; set; }
    }
}
