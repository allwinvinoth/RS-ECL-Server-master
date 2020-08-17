using LIS.ServiceContracts.ServiceObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LIS.ServiceContracts.Services
{
    public interface IAppointmentsService
    {
        Task<AppointmentServiceObject> CreateAppointmentAsync(AppointmentServiceObject appointmentServiceObject, CancellationToken token);

        Task<IEnumerable<AppointmentServiceObject>> SearchAppointmentAsync(string searchQuery, CancellationToken token);
    }
}
