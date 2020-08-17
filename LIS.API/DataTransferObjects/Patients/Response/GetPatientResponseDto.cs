using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LIS.API.DataTransferObjects.Patients.Response
{
    public sealed class GetPatientResponseDto
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string PrimaryEmail { get; set; }

        public string SecondaryEmail { get; set; }

        public string PrimaryContactNumber { get; set; }

        public string SecondaryContactNumber { get; set; }

        public string Comments { get; set; }

        public int GenderId { get; set; }
    }
}
