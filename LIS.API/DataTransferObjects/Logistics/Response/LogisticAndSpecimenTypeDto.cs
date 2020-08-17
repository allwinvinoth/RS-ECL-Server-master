using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LIS.API.DataTransferObjects.Logistics.Response
{
    public sealed class LogisticAndSpecimenTypeDto
    {
        public SpecimenTypeDto SpecimenType { get; set; }
    }

    public sealed class SpecimenTypeDto
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
