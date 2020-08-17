using System;
using System.Collections.Generic;
using System.Text;

namespace LIS.ServiceContracts.ServiceObjects
{
    public sealed class LogisticAndSpecimenServiceObject
    {
        public int Id { get; set; }

        public int LogisticId { get; set; }

        public int SpecimenTypeId { get; set; }

        public int SpecimenCount { get; set; }

        public LogisticAndServiceObject Logistic { get; set; }

        public ContainerTypeServiceObject SpecimenType { get; set; }
    }
}
