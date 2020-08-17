using System;
using System.Collections.Generic;
using System.Text;

namespace LIS.ServiceContracts.ServiceObjects
{
    public sealed class AppointmentServiceObject
    {
        public int Id { get; set; }

        public DateTime From { get; set; }

        public DateTime To { get; set; }

        public string Comment { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string PrimaryPhoneNumber { get; set; }

        public string SecondaryPhoneNumber { get; set; }

        public int AppointmentStatusId { get; set; }

        public AppointmentStatusServiceObject AppointmentStatus { get; set; }
    }
}
