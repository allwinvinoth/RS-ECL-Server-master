using System.ComponentModel.DataAnnotations.Schema;
using LIS.DataContracts.Entities;
using Microsoft.EntityFrameworkCore;

namespace LIS.Data
{
    public sealed class LISDbContext : DbContext
    {
        public LISDbContext(DbContextOptions<LISDbContext> options) : base(options)
        {

        }

        public DbSet<ModuleEntity> Modules { get; set; }

        public DbSet<PageEntity> Pages { get; set; }

        public DbSet<TestEntity> Tests { get; set; }

        public DbSet<DepartmentEntity> Departments { get; set; }

        public DbSet<CategoryEntity> Categories { get; set; }

        public DbSet<ModulePageMappingEntity> Modules_Pages_Mapping { get; set; }
        public DbSet<OrganisationEntity> Organisations { get; set; }

        public DbSet<BranchEntity> Branches { get; set; }

        public DbSet<GenderEntity> Genders { get; set; }

        public DbSet<TestProfileEntity> TestProfiles { get; set; }

        public DbSet<SampleTypeEntity> SampleTypes { get; set; }

        public DbSet<ContainerTypeEntity> ContainerTypes { get; set; }

        public DbSet<SampleEntity> Samples { get; set; }

        public DbSet<HomeCollectionEntity> HomeCollections { get; set; }

        public DbSet<LogisticEntity> Logistics { get; set; }

        public DbSet<UserEntity> Users { get; set; }

        public DbSet<LogisticAndLogisticTypeEntity> LogisticAndLogisticTypes { get; set; }

        public DbSet<LogisticTypeEntity> LogisticTypes { get; set; }

        public DbSet<LogisticAndSpecimenEntity> LogisticAndSpecimenTypes { get; set; }

        public DbSet<AppointmentEntity> Appointments { get; set; }

        public DbSet<AppointmentStatusEntity> AppointmentStatus { get; set; }
    }
}