using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LIS.API.DataTransferObjects.Logistics.Request
{
    public sealed class SpecimenTypeRequestDto
    {
        public int SpecimenTypeId { get; set; }

        public int SpecimenCount { get; set; }
    }
}
