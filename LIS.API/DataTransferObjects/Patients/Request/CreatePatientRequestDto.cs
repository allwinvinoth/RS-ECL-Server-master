using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LIS.API.DataTransferObjects.Patients.Request
{
    public sealed class CreatePatientRequestDto
    {
        public string Name { get; set; }

        public string DateOfBirth { get; set; }

        public string PrimaryEmail { get; set; }

        public string SecondaryEmail { get; set; }

        public string PrimaryContactNumber { get; set; }

        public string SecondaryContactNumber { get; set; }

        public string Comments { get; set; }

        public int GenderId { get; set; }

        public long ModifiedBy { get; set; }
    }
}
