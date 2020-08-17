using System;
using System.Collections.Generic;
using System.Text;

namespace LIS.ServiceContracts.ServiceObjects
{
    public sealed class AppointmentStatusServiceObject
    {
        public int Id { get; set; }

        public string Status { get; set; }
    }
}
