using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LIS.API.DataTransferObjects.Appointments.Response
{
    public sealed class CreateAppointmentResponseDto
    {
        public long Id { get; set; }

        public DateTime From { get; set; }

        public DateTime To { get; set; }

        public string Comment { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string DateOfBirth { get; set; }

        public string PrimaryPhoneNumber { get; set; }

        public string SecondaryPhoneNumber { get; set; }

        public AppointmentStatusResponseDto AppointmentStatus { get; set; }
    }
}
