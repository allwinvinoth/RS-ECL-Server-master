using LIS.DataContracts.Entities;
using LIS.DataContracts.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LIS.Data.Repositories
{
    public sealed class PatientRepository : IPatientRepository
    {
        private readonly LISDbContext _dbContext;

        public PatientRepository(LISDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<UserEntity> CreatePatientAsync(UserEntity patient, CancellationToken token)
        {
            await _dbContext.Users.AddAsync(patient, token);
            await _dbContext.SaveChangesAsync(token);
            return patient;
        }

        public async Task<UserEntity> GetPatientByIdAsync(int patientId, CancellationToken token)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(patient => patient.Id == patientId, token);
        }

        public async Task<UserEntity> GetPatientByEmailIdAsync(string email, CancellationToken token)
        {
            Expression<Func<UserEntity, bool>> getPatientByEmailIdCondition = patient => patient.PrimaryEmail == email;
            return await _dbContext.Users
                                   .FirstOrDefaultAsync(getPatientByEmailIdCondition, token);
        }

        public async Task<IEnumerable<UserEntity>> SearchPatientAsync(string searchQuery, CancellationToken token)
        {
            return await _dbContext.Users.Where(
            patient => (patient.Id).ToString() == searchQuery ||
                        (patient.Name != null && patient.Name.Contains(searchQuery)) ||
                        (patient.PrimaryEmail != null && patient.PrimaryEmail.Contains(searchQuery)) ||
                        (patient.SecondaryEmail != null && patient.SecondaryEmail.Contains(searchQuery)) ||
                        patient.PrimaryContactNumber == searchQuery ||
                        patient.SecondaryContactNumber == searchQuery).ToListAsync(token);
        }
    }
}
