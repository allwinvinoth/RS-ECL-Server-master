using LIS.API.DataTransferObjects.Logistics.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LIS.API.DataTransferObjects.Logistics.Request
{
    public sealed class CreateLogisticRequestDto
    {
        public string Date { get; set; }

        public string Clinic { get; set; }

        public string CalledBy { get; set; }

        public int DriverId { get; set; }

        public int NoOfTRFs { get; set; }

        public string Temperature { get; set; }

        public bool Stat { get; set; }

        public string Remarks { get; set; }

        public string Signature { get; set; }

        public IEnumerable<string> LogisticTypeIds { get; set; }

        public IEnumerable<SpecimenTypeRequestDto> SpecimenTypes { get; set; }
    }
}
