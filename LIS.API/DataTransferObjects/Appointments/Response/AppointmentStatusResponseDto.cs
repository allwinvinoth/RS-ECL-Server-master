using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LIS.API.DataTransferObjects.Appointments.Response
{
    public sealed class AppointmentStatusResponseDto
    {
        public int Id { get; set; }

        public string Status { get; set; }
    }
}
