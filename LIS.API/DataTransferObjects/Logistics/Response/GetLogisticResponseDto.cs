using LIS.API.DataTransferObjects.Logistics.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LIS.API.DataTransferObjects.Logistics.Response
{
    public sealed class GetLogisticResponseDto
    {
        public string Id { get; set; }

        public string Date { get; set; }

        public string Clinic { get; set; }

        public string CalledBy { get; set; }

        public string NoOfTRFs { get; set; }

        public string Temperature { get; set; }

        public string Stat { get; set; }

        public string Remarks { get; set; }

        public string Signature { get; set; }

        public DriverResponseDto Driver { get; set; }

        public IEnumerable<LogisticAndLogisticTypeDto> LogisticAndLogisticTypes { get; set; }

        public IEnumerable<LogisticAndSpecimenTypeDto> LogisticSpecimenTypes { get; set; }
    }
}
