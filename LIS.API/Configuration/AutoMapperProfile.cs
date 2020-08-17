using AutoMapper;
using LIS.API.DataTransferObjects.Branches.Request;
using LIS.API.DataTransferObjects.Branches.Response;
using LIS.API.DataTransferObjects.Departments.Request;
using LIS.API.DataTransferObjects.Departments.Response;
using LIS.API.DataTransferObjects.Modules;
using LIS.API.DataTransferObjects.Modules.Request;
using LIS.API.DataTransferObjects.Modules.Response;
using LIS.API.DataTransferObjects.Organisations.Request;
using LIS.API.DataTransferObjects.Organisations.Response;
using LIS.API.DataTransferObjects.Pages.Request;
using LIS.API.DataTransferObjects.Pages.Response;

using LIS.API.DataTransferObjects.Categories.Request;
using LIS.API.DataTransferObjects.Categories.Response;

using LIS.API.DataTransferObjects.TestProfiles.Request;
using LIS.API.DataTransferObjects.TestProfiles.Response;

using LIS.API.DataTransferObjects.Tests.Request;
using LIS.API.DataTransferObjects.Tests.Response;
using LIS.ServiceContracts.ServiceObjects;
using LIS.API.DataTransferObjects.Gender.Response;
using LIS.API.DataTransferObjects.Gender.Request;
using System;
using LIS.API.DataTransferObjects.SampleTypes.Request;
using LIS.API.DataTransferObjects.SampleTypes.Response;
using LIS.API.DataTransferObjects.ContainerTypes.Request;
using LIS.API.DataTransferObjects.ContainerTypes.Response;
using LIS.API.DataTransferObjects.Samples.Request;
using LIS.API.DataTransferObjects.Samples.Response;
using LIS.API.DataTransferObjects.HomeCollection.Request;
using LIS.API.DataTransferObjects.HomeCollection.Response;
using LIS.API.DataTransferObjects.Logistics.Request;
using LIS.API.DataTransferObjects.Logistics.Response;
using LIS.API.DataTransferObjects.Patients.Request;
using LIS.API.DataTransferObjects.Patients.Response;
using LIS.API.DataTransferObjects.Appointments.Request;
using LIS.API.DataTransferObjects.Appointments.Response;

namespace LIS.API.Configuration
{
    public sealed class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            this.CreateMapForModules();
            this.CreateMapForPages();
            this.CreateMapForTests();
            this.CreateMapForOrganisations();
            this.CreateMapForBranches();

            this.CreateMapForCategories();
            this.CreateMapForGender();

            this.CreateMapForTestProfiles();
            this.CreateMapForDepartments();
            this.CreateMapForSampleTypes();
            this.CreateMapForContainerTypes();
            this.CreateMapForSamples();
            this.CreateMapForHomeCollections();
            this.CreateMapForLogistics();

            this.CreateMapForPatients();
            this.CreateMapForAppointments();
        }        

        private void CreateMapForModules()
        {
            this.CreateMap<CreateModuleRequestDto, ModuleServiceObject>();
            this.CreateMap<ModuleServiceObject, CreateModuleResponseDto>();
            this.CreateMap<UpdateModuleRequestDto, ModuleServiceObject>();
            this.CreateMap<ModuleServiceObject, UpdateModuleResponseDto>();
            this.CreateMap<ModuleServiceObject, GetModuleResponseDto>();
            this.CreateMap<AddModulePageMappingRequestDto, ModulePageMappingServiceObject>();
            this.CreateMap<ModulePageMappingServiceObject, AddModulePageMappingResponseDto>();
        }

        private void CreateMapForPages()
        {
            this.CreateMap<CreatePageRequestDto, PageServiceObject>();
            this.CreateMap<PageServiceObject, CreatePageResponseDto>();
            this.CreateMap<UpdatePageRequestDto, PageServiceObject>();
            this.CreateMap<PageServiceObject, UpdatePageResponseDto>();
            this.CreateMap<PageServiceObject, GetPageResponseDto>();
            this.CreateMap<PageServiceObject, GetPagesByModuleIdResponseDto>();
        }

        private void CreateMapForTests()
        {
            this.CreateMap<AddTestRequestDto, TestServiceObject>();
            this.CreateMap<UpdateTestRequestDto, TestServiceObject>();

            this.CreateMap<TestServiceObject, AddTestResponseDto>();
            this.CreateMap<TestServiceObject, UpdateTestResponseDto>();

            this.CreateMap<TestServiceObject, GetTestResponseDto>();
        }

        private void CreateMapForOrganisations()
        {
            this.CreateMap<CreateOrganisationRequestDto, OrganisationServiceObject>();
            this.CreateMap<OrganisationServiceObject, CreateOrganisationResponseDto>();

            this.CreateMap<UpdateOrganisationRequestDto, OrganisationServiceObject>();
            this.CreateMap<OrganisationServiceObject, UpdateOrganisationResponseDto>();

            this.CreateMap<OrganisationServiceObject, GetOrganisationResponseDto>();
        }

        private void CreateMapForBranches()
        {
            this.CreateMap<CreateBranchRequestDto, BranchServiceObject>();
            this.CreateMap<BranchServiceObject, CreateBranchResponseDto>();

            this.CreateMap<UpdateBranchRequestDto, BranchServiceObject>();
            this.CreateMap<BranchServiceObject, UpdateBranchResponseDto>();

            this.CreateMap<BranchServiceObject, GetBranchResponseDto>();
        }

        private void CreateMapForCategories()
        {
            this.CreateMap<AddCategoryRequestDto, CategoryServiceObject>();
            this.CreateMap<CategoryServiceObject, AddCategoryResponseDto>();

            this.CreateMap<UpdateCategoryRequestDto, CategoryServiceObject>();
            this.CreateMap<CategoryServiceObject, UpdateCategoryResponseDto>();

            this.CreateMap<CategoryServiceObject, GetCategoryResponseDto>();
        }

        private void CreateMapForGender()
        {
            this.CreateMap<AddGenderRequestDto, GenderServiceObject>();
            this.CreateMap<GenderServiceObject, AddGenderResponseDto>();

            this.CreateMap<UpdateGenderRequestDto, GenderServiceObject>();
            this.CreateMap<GenderServiceObject, UpdateGenderResponseDto>();

            this.CreateMap<GenderServiceObject, GetGenderResponseDto>();
        }
        private void CreateMapForTestProfiles()
        {
            this.CreateMap<CreateTestProfileRequestDto, TestProfileServiceObject>();
            this.CreateMap<UpdateTestProfileRequestDto, TestProfileServiceObject>();

            this.CreateMap<TestProfileServiceObject, CreateTestProfileResponseDto>();
            this.CreateMap<TestProfileServiceObject, UpdateTestProfileResponseDto>();

            this.CreateMap<TestProfileServiceObject, GetTestProfileResponseDto>();
        }
        private void CreateMapForDepartments()
        {
            this.CreateMap<CreateDepartmentRequestDto, DepartmentServiceObject>();
            this.CreateMap<DepartmentServiceObject, CreateDepartmentResponseDto>();

            this.CreateMap<UpdateDepartmentRequestDto, DepartmentServiceObject>();
            this.CreateMap<DepartmentServiceObject, UpdateDepartmentResponseDto>();

            this.CreateMap<DepartmentServiceObject, GetDepartmentResponseDto>();
        }

        private void CreateMapForSampleTypes()
        {
            this.CreateMap<CreateSampleTypeRequestDto, SampleTypeServiceObject>();
            this.CreateMap<SampleTypeServiceObject, CreateSampleTypeResponseDto>();

            this.CreateMap<SampleTypeServiceObject, GetSampleTypeResponseDto>();
        }

        private void CreateMapForContainerTypes()
        {
            this.CreateMap<CreateContainerTypeRequestDto, ContainerTypeServiceObject>();
            this.CreateMap<ContainerTypeServiceObject, CreateContainerTypeResponseDto>();

            this.CreateMap<ContainerTypeServiceObject, GetContainerTypeResponseDto>();
        }

        private void CreateMapForSamples()
        {
            this.CreateMap<CreateSampleRequestDto, SampleServiceObject>();
            this.CreateMap<SampleServiceObject, CreateSampleResponseDto>();

            this.CreateMap<UpdateSampleRequestDto, SampleServiceObject>();
            this.CreateMap<SampleServiceObject, UpdateSampleResponseDto>();

            this.CreateMap<SampleTypeServiceObject, SampleTypeResponseDto>();
            this.CreateMap<ContainerTypeServiceObject, ContainerTypeResponseDto>();

            this.CreateMap<SampleServiceObject, GetSampleResponseDto>();
        }

        private void CreateMapForHomeCollections()
        {
            this.CreateMap<CreateHomeCollectionRequestDto, HomeCollectionServiceObject>()
                .ForMember(so => so.Organization, opt => opt.MapFrom(dto => dto.Referral.Organization))
                .ForMember(so => so.DoctorId, opt => opt.MapFrom(dto => dto.Referral.DoctorId))
                .ForMember(so => so.ScheduledDate, opt => opt.MapFrom(dto => dto.Collection.ScheduledDate))
                .ForMember(so => so.Area, opt => opt.MapFrom(dto => dto.Collection.Area))
                .ForMember(so => so.City, opt => opt.MapFrom(dto => dto.Collection.City))
                .ForMember(so => so.PostalCode, opt => opt.MapFrom(dto => dto.Collection.PostalCode))
                .ForMember(so => so.Country, opt => opt.MapFrom(dto => dto.Collection.Country))
                .ForMember(so => so.Comment, opt => opt.MapFrom(dto => dto.Collection.Comment));

            this.CreateMap<HomeCollectionServiceObject, CreateHomeCollectionResponseDto>()
                .ForMember(dto => dto.Referral, opt => opt.MapFrom(so => so))
                .ForMember(dto => dto.Collection, opt => opt.MapFrom(so => so));
          
            this.CreateMap<UpdateHomeCollectionRequestDto, HomeCollectionServiceObject>()
                .ForMember(so => so.Organization, opt => opt.MapFrom(dto => dto.Referral.Organization))
                .ForMember(so => so.DoctorId, opt => opt.MapFrom(dto => dto.Referral.DoctorId))
                .ForMember(so => so.ScheduledDate, opt => opt.MapFrom(dto => dto.Collection.ScheduledDate))
                .ForMember(so => so.Area, opt => opt.MapFrom(dto => dto.Collection.Area))
                .ForMember(so => so.City, opt => opt.MapFrom(dto => dto.Collection.City))
                .ForMember(so => so.PostalCode, opt => opt.MapFrom(dto => dto.Collection.PostalCode))
                .ForMember(so => so.Country, opt => opt.MapFrom(dto => dto.Collection.Country))
                .ForMember(so => so.Comment, opt => opt.MapFrom(dto => dto.Collection.Comment));

            this.CreateMap<HomeCollectionServiceObject, UpdateHomeCollectionResponseDto>()
                .ForMember(dto => dto.Referral, opt => opt.MapFrom(so => so))
                .ForMember(dto => dto.Collection, opt => opt.MapFrom(so => so));
            
            this.CreateMap<HomeCollectionServiceObject, GetHomeCollectionResponseDto>()
                .ForMember(dto => dto.Referral, opt => opt.MapFrom(so => so))
                .ForMember(dto => dto.Collection, opt => opt.MapFrom(so => so));
           
            this.CreateMap<HomeCollectionServiceObject, CreateReferralInformationResponseDto>();
            this.CreateMap<HomeCollectionServiceObject, CreateCollectionInformationResponseDto>();
            this.CreateMap<HomeCollectionServiceObject, UpdateReferralInformationResponseDto>();
            this.CreateMap<HomeCollectionServiceObject, UpdateCollectionInformationResponseDto>();
            this.CreateMap<HomeCollectionServiceObject, GetReferralInformationResponseDto>();
            this.CreateMap<HomeCollectionServiceObject, GetCollectionInformationResponseDto>();

            this.CreateMap<GenderServiceObject, CreateGenderDto>();
            this.CreateMap<GenderServiceObject, GetGenderDto>();
            this.CreateMap<GenderServiceObject, UpdateGenderDto>();
        }

        private void CreateMapForLogistics()
        {
            this.CreateMap<CreateLogisticRequestDto, LogisticAndServiceObject>()
                .ForMember(so => so.LogisticAndLogisticTypes, opt => opt.MapFrom(dto => dto.LogisticTypeIds))
                .ForMember(so => so.LogisticSpecimenTypes, opt => opt.MapFrom(dto => dto.SpecimenTypes));
            this.CreateMap<LogisticAndServiceObject, CreateLogisticResponseDto>();

            this.CreateMap<string, LogisticAndLogisticTypeSeviceObject>()
                .ForMember(so => so.LogisticTypeId, opt => opt.MapFrom(dto => dto));
            this.CreateMap<LogisticAndLogisticTypeSeviceObject, LogisticAndLogisticTypeDto>();

            this.CreateMap<LogisticTypeDto, LogisticTypeServiceObject>();
            this.CreateMap<LogisticTypeServiceObject, LogisticTypeDto>();

            this.CreateMap<UpdateLogisticRequestDto, LogisticAndServiceObject>()
                .ForMember(so => so.LogisticAndLogisticTypes, opt => opt.MapFrom(dto => dto.LogisticTypeIds))
                .ForMember(so => so.LogisticSpecimenTypes, opt => opt.MapFrom(dto => dto.SpecimenTypes));
            this.CreateMap<LogisticAndServiceObject, UpdateLogisticResponseDto>();

            this.CreateMap<UserServiceObject, DriverResponseDto>();

            this.CreateMap<LogisticAndServiceObject, GetLogisticResponseDto>();

            this.CreateMap<SpecimenTypeRequestDto, LogisticAndSpecimenServiceObject>();
            this.CreateMap<LogisticAndSpecimenServiceObject, LogisticAndSpecimenTypeDto>();

            this.CreateMap<SpecimenTypeDto, ContainerTypeServiceObject>();
            this.CreateMap<ContainerTypeServiceObject, SpecimenTypeDto>();

        }

        private void CreateMapForPatients()
        {
            this.CreateMap<CreatePatientRequestDto, UserServiceObject>();
            this.CreateMap<UserServiceObject, CreatePatientResponseDto>();
            this.CreateMap<UserServiceObject, GetPatientResponseDto>();
        }

        private void CreateMapForAppointments()
        {
            this.CreateMap<CreateAppointmentRequestDto, AppointmentServiceObject>();
            this.CreateMap<AppointmentServiceObject, CreateAppointmentResponseDto>();
            this.CreateMap<AppointmentServiceObject, SearchAppointmentsResponseDto>();

            this.CreateMap<AppointmentStatusServiceObject, AppointmentStatusResponseDto>();
        }
    }
}