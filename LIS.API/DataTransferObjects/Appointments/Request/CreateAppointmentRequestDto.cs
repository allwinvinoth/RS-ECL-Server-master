using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LIS.API.DataTransferObjects.Appointments.Request
{
    public sealed class CreateAppointmentRequestDto
    {
        public string From { get; set; }

        public string To { get; set; }

        public string Comment { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string DateOfBirth { get; set; }

        public string PrimaryPhoneNumber { get; set; }

        public string SecondaryPhoneNumber { get; set; }

        public int AppointmentStatusId { get; set; }
    }
}
