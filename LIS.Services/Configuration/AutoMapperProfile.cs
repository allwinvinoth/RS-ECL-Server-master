using System;
using AutoMapper;
using LIS.DataContracts.Entities;
using LIS.ServiceContracts.ServiceObjects;

namespace LIS.Services.Configuration
{
    public sealed class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            this.CreateMapForModules();
            this.CreateMapForPages();
            this.CreateMapForTests();
            this.CreateMapForDepartments();
            this.CreateMapForOrganisations();
            this.CreateMapForBranches();

            this.CreateMapForCategories();
            this.CreateMapForGender();

            this.CreateMapForTestProfiles();
            this.CreateMapForSampleTypes();
            this.CreateMapForContainerTypes();
            this.CreateMapForSamples();

            this.CreateMapForHomeCollection();

            this.CreateMapForLogistics();

            this.CreateMapForPatients();
            this.CreateMapForAppointments();
        }
        
        private void CreateMapForModules()
        {
            this.CreateMap<ModuleServiceObject, ModuleEntity>()
                .ForMember(moduleEntity => moduleEntity.IsActive, opt => opt.MapFrom(x => true))
                .ForMember(moduleEntity => moduleEntity.ModifiedOn, opt => opt.MapFrom(x => DateTime.UtcNow));
            this.CreateMap<ModuleEntity, ModuleServiceObject>();
            this.CreateMap<ModulePageMappingServiceObject, ModulePageMappingEntity>()
                .ForMember(modulePageMappingEntity => modulePageMappingEntity.ModifiedOn, opt => opt.MapFrom(x => DateTime.UtcNow));
            this.CreateMap<ModulePageMappingEntity, ModulePageMappingServiceObject>();
        }

        private void CreateMapForPages()
        {
            this.CreateMap<PageServiceObject, PageEntity>()
                .ForMember(pageEntity => pageEntity.ModifiedOn, opt => opt.MapFrom(x => DateTime.UtcNow));
            this.CreateMap<PageEntity, PageServiceObject>();
        }

        private void CreateMapForTests()
        {
            this.CreateMap<TestServiceObject, TestEntity>()
                .ForMember(testEntity => testEntity.IsActive, opt => opt.MapFrom(x => true))
                .ForMember(testEntity => testEntity.ModifiedOn, opt => opt.MapFrom(x => DateTime.UtcNow));

            this.CreateMap<TestEntity, TestServiceObject>();
        }

        private void CreateMapForTestProfiles()
        {
            this.CreateMap<TestProfileServiceObject, TestProfileEntity>()
                .ForMember(testProfileEntity => testProfileEntity.IsActive, opt => opt.MapFrom(x => true))
                .ForMember(testProfileEntity => testProfileEntity.ModifiedOn, opt => opt.MapFrom(x => DateTime.UtcNow));

            this.CreateMap<TestProfileEntity, TestProfileServiceObject>();
        }

        private void CreateMapForDepartments()
        {
            this.CreateMap<DepartmentServiceObject, DepartmentEntity>()
                .ForMember(departmentEntity => departmentEntity.IsActive, opt => opt.MapFrom(x => true))
                .ForMember(departmentEntity => departmentEntity.ModifiedOn, opt => opt.MapFrom(x => DateTime.UtcNow));
            this.CreateMap<DepartmentEntity, DepartmentServiceObject>();
        }

        private void CreateMapForOrganisations()
        {
            this.CreateMap<OrganisationServiceObject, OrganisationEntity>()
                .ForMember(organisationEntity => organisationEntity.IsActive, opt => opt.MapFrom(x => true))
                .ForMember(organisationEntity => organisationEntity.ModifiedOn, opt => opt.MapFrom(x => DateTime.UtcNow));
            this.CreateMap<OrganisationEntity, OrganisationServiceObject>();
        }
        private void CreateMapForBranches()
        {
            this.CreateMap<BranchServiceObject, BranchEntity>()
                .ForMember(branchEntity => branchEntity.IsActive, opt => opt.MapFrom(x => true))
                .ForMember(branchEntity => branchEntity.ModifiedOn, opt => opt.MapFrom(x => DateTime.UtcNow));
            this.CreateMap<BranchEntity, BranchServiceObject>();
        }
        private void CreateMapForCategories()
        {
            this.CreateMap<CategoryServiceObject, CategoryEntity>()
                .ForMember(categoryEntity => categoryEntity.IsActive, opt => opt.MapFrom(x => true))
                .ForMember(categoryEntity => categoryEntity.ModifiedOn, opt => opt.MapFrom(x => DateTime.UtcNow));
            this.CreateMap<CategoryEntity, CategoryServiceObject>();
        }

        private void CreateMapForGender()
        {
            this.CreateMap<GenderServiceObject, GenderEntity>()
                .ForMember(genderEntity => genderEntity.IsActive, opt => opt.MapFrom(x => true))
                .ForMember(genderEntity => genderEntity.ModifiedOn, opt => opt.MapFrom(x => DateTime.UtcNow));
            this.CreateMap<GenderEntity, GenderServiceObject>();
        }

        private void CreateMapForSampleTypes()
        {
            this.CreateMap<SampleTypeServiceObject, SampleTypeEntity>()
                .ForMember(sampleTypeEntity=>sampleTypeEntity.IsActive, opt=>opt.MapFrom(x=>true))
                .ForMember(sampleTypeEntity => sampleTypeEntity.ModifiedOn, opt => opt.MapFrom(x => DateTime.UtcNow));

            this.CreateMap<SampleTypeEntity, SampleTypeServiceObject>();
        }

        private void CreateMapForContainerTypes()
        {
            this.CreateMap<ContainerTypeServiceObject, ContainerTypeEntity>()
                .ForMember(containerTypeEntity => containerTypeEntity.IsActive, opt => opt.MapFrom(x => true))
                .ForMember(containerTypeEntity => containerTypeEntity.ModifiedOn, opt => opt.MapFrom(x => DateTime.UtcNow));

            this.CreateMap<ContainerTypeEntity, ContainerTypeServiceObject>();
        }

        private void CreateMapForSamples()
        {
            this.CreateMap<SampleServiceObject, SampleEntity>()
                .ForMember(sampleEntity => sampleEntity.IsActive, opt => opt.MapFrom(x => true))
                .ForMember(sampleEntity => sampleEntity.ModifiedOn, opt => opt.MapFrom(x => DateTime.UtcNow));

            this.CreateMap<SampleEntity, SampleServiceObject>();

            this.CreateMap<SampleTypeEntity, SampleTypeServiceObject>();
            this.CreateMap<ContainerTypeEntity, ContainerTypeServiceObject>();

        }

        public void CreateMapForHomeCollection()
        {
            this.CreateMap<HomeCollectionServiceObject, HomeCollectionEntity>()
                .ForMember(homeCollectionEntity => homeCollectionEntity.IsActive, opt => opt.MapFrom(x => true))
                .ForMember(homeCollectionEntity => homeCollectionEntity.ModifiedOn, opt => opt.MapFrom(x => DateTime.UtcNow));

            this.CreateMap<HomeCollectionEntity, HomeCollectionServiceObject>();
        }

        public void CreateMapForLogistics()
        {
            this.CreateMap<LogisticAndServiceObject, LogisticEntity>()
                .ForMember(logisticEntity => logisticEntity.IsActive, opt => opt.MapFrom(x => true))
                .ForMember(logisticEntity => logisticEntity.ModifiedOn, opt => opt.MapFrom(x => DateTime.UtcNow));

            this.CreateMap<LogisticEntity, LogisticAndServiceObject>();

            this.CreateMap<UserEntity, UserServiceObject>();

            this.CreateMap<LogisticAndLogisticTypeSeviceObject, LogisticAndLogisticTypeEntity>();
            this.CreateMap<LogisticAndLogisticTypeEntity, LogisticAndLogisticTypeSeviceObject>();

            this.CreateMap<LogisticTypeServiceObject, LogisticTypeEntity>();
            this.CreateMap<LogisticTypeEntity, LogisticTypeServiceObject>();

            this.CreateMap<LogisticAndSpecimenServiceObject, LogisticAndSpecimenEntity>();
            this.CreateMap<LogisticAndSpecimenEntity, LogisticAndSpecimenServiceObject>();

            this.CreateMap<ContainerTypeServiceObject, ContainerTypeEntity>();
            this.CreateMap<ContainerTypeEntity, ContainerTypeServiceObject>();
        }

        private void CreateMapForPatients()
        {
            this.CreateMap<UserServiceObject, UserEntity>()
                .ForMember(patientEntity => patientEntity.IsActive, opt => opt.MapFrom(x => true))
                .ForMember(patientEntity => patientEntity.ModifiedOn, opt => opt.MapFrom(x => DateTime.UtcNow));

            this.CreateMap<UserEntity, UserServiceObject>();
        }

        private void CreateMapForAppointments()
        {
            this.CreateMap<AppointmentServiceObject, AppointmentEntity>()
                .ForMember(aapointmentEntity => aapointmentEntity.IsActive, opt => opt.MapFrom(x => true))
                .ForMember(aapointmentEntity => aapointmentEntity.ModifiedOn, opt => opt.MapFrom(x => DateTime.UtcNow));

            this.CreateMap<AppointmentEntity, AppointmentServiceObject>();

            this.CreateMap<AppointmentStatusEntity, AppointmentStatusServiceObject>();
        }
    }
}