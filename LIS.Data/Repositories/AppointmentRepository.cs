using LIS.DataContracts.Entities;
using LIS.DataContracts.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace LIS.Data.Repositories
{
    public sealed class AppointmentRepository : IAppointmentRepository
    {
        private readonly LISDbContext _dbContext;

        public AppointmentRepository(LISDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<AppointmentEntity> CreateAppointmentAsync(AppointmentEntity appointmentEntity, CancellationToken token)
        {
            await _dbContext.Appointments.AddAsync(appointmentEntity, token);
            await _dbContext.SaveChangesAsync(token);
            return await _dbContext.Appointments
                                .Include(x => x.AppointmentStatus)
                                .SingleAsync(appointment => appointment.Id == appointmentEntity.Id, token);
        }

        public async Task<IEnumerable<AppointmentEntity>> SearchAppointmentAsync(string searchQuery, CancellationToken token)
        {
            return await _dbContext.Appointments
                                .Include(x => x.AppointmentStatus)
                                .Where(appointment => (appointment.Email == searchQuery || appointment.PrimaryPhoneNumber == searchQuery || appointment.SecondaryPhoneNumber == searchQuery) && appointment.IsActive).ToListAsync(token);
        }
    }
}
