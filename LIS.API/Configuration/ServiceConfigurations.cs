using System;
using System.Collections.Generic;
using System.Reflection;
using AutoMapper;
using LIS.API.Controllers;
using LIS.API.DataTransferObjects.Branches.Request;
using LIS.API.DataTransferObjects.Departments.Request;
using LIS.API.DataTransferObjects.Modules.Request;
using LIS.API.DataTransferObjects.Organisations.Request;
using LIS.API.DataTransferObjects.Pages.Request;

using LIS.API.DataTransferObjects.Categories.Request;

using LIS.API.DataTransferObjects.TestProfiles.Request;

using LIS.API.DataTransferObjects.Tests.Request;
using LIS.API.Validators.Branches;
using LIS.API.Validators.Departments;
using LIS.API.Validators.Modules;
using LIS.API.Validators.Organisations;
using LIS.API.Validators.Pages;

using LIS.API.Validators.Categories;

using LIS.API.Validators.TestProfiles;

using LIS.API.Validators.Tests;
using LIS.Data;
using LIS.Data.Repositories;
using LIS.DataContracts.Repositories;
using LIS.ServiceContracts.Services;
using LIS.ServiceContracts.Validations;
using LIS.Services.Services;
using LIS.Services.Validations;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using LIS.API.DataTransferObjects.Gender.Request;
using LIS.API.Validators.Gender;
using LIS.API.DataTransferObjects.SampleTypes.Request;
using LIS.API.Validators.SampleTypes;
using LIS.API.DataTransferObjects.ContainerTypes.Request;
using LIS.API.Validators.ContainerTypes;
using LIS.API.DataTransferObjects.Samples.Request;
using LIS.API.Validators.Samples;
using LIS.API.DataTransferObjects.Patients.Request;
using LIS.API.Validators.Patients;
using LIS.API.DataTransferObjects.Appointments.Request;
using LIS.API.Validators.Appointments;

namespace LIS.API.Configuration
{
    public static class ServiceConfigurations
    {
        public static void AddServices(this IServiceCollection serviceCollection)
        {
            if (serviceCollection == null)
            {
                throw new ArgumentNullException(nameof(serviceCollection));
            }

            serviceCollection.AddScoped<IModulesService, ModulesService>();
            serviceCollection.AddScoped<IPagesService, PagesService>();
            serviceCollection.AddScoped<ITestsService, TestsService>();
            serviceCollection.AddScoped<IOrganisationService, OrganisationService>();
            serviceCollection.AddScoped<IBranchService, BranchService>();

            serviceCollection.AddScoped<ICategoryService, CategoryService>();
            serviceCollection.AddScoped<IGenderService,GenderService>();

            serviceCollection.AddScoped<ITestProfilesService, TestProfilesService>();
            serviceCollection.AddScoped<IDepartmentService, DepartmentService>();

            serviceCollection.AddScoped<ISampleTypeService, SampleTypeService>();
            serviceCollection.AddScoped<IContainerTypeService, ContainerTypeService>();
            serviceCollection.AddScoped<ISampleService, SampleService>();

            serviceCollection.AddScoped<IHomeCollectionService, HomeCollectionService> ();

            serviceCollection.AddScoped<ILogisticService, LogisticService>();

            serviceCollection.AddScoped<IPatientsService, PatientsService>();
            serviceCollection.AddScoped<IAppointmentsService, AppointmentsService>();
        }

        public static void AddRepositories(this IServiceCollection serviceCollection)
        {
            if (serviceCollection == null)
            {
                throw new ArgumentNullException(nameof(serviceCollection));
            }

            serviceCollection.AddScoped<IModuleRepository, ModuleRepository>();
            serviceCollection.AddScoped<IPageRepository, PageRepository>();
            serviceCollection.AddScoped<ITestRepository, TestRepository>();
            serviceCollection.AddScoped<IOrganisationRepository, OrganisationRepository>();
            serviceCollection.AddScoped<IBranchRepository, BranchRepository>();
            serviceCollection.AddScoped<ICategoryRepository, CategoryRepository>();
            serviceCollection.AddScoped<IDepartmentRepository, DepartmentRepository>();
            serviceCollection.AddScoped<IGenderRepository, GenderRepository>();
            serviceCollection.AddScoped<ITestProfileRepository, TestProfileRepository>();
            serviceCollection.AddScoped<ISampleTypeRepository, SampleTypeRepository>();
            serviceCollection.AddScoped<IContainerTypeRepository, ContainerTypeRepository>();
            serviceCollection.AddScoped<ISampleRepository, SampleRepository>();
            serviceCollection.AddScoped<IHomeCollectionRepository, HomeCollectionRepository>();
            serviceCollection.AddScoped<ILogisticRepository, LogisticRepository>();

            serviceCollection.AddScoped<IPatientRepository, PatientRepository>();
            serviceCollection.AddScoped<IAppointmentRepository, AppointmentRepository>();
        }

        public static void AddSqlServerDbContext(this IServiceCollection serviceCollection, string connectionString)
        {
            if (serviceCollection == null)
            {
                throw new ArgumentNullException(nameof(serviceCollection));
            }

            serviceCollection.AddDbContext<LISDbContext>(options => options.UseSqlServer(connectionString));
        }

        public static void AddAutoMapperProfiles(this IServiceCollection serviceCollection)
        {
            if (serviceCollection == null)
            {
                throw new ArgumentNullException(nameof(serviceCollection));
            }

            var autoMapperAssemblies = new List<Assembly>
            {
                typeof(ModulesController).GetTypeInfo().Assembly,
                typeof(ModulesService).GetTypeInfo().Assembly
            };

            serviceCollection.AddAutoMapper(autoMapperAssemblies);
        }

        public static void AddValidators(this IServiceCollection serviceCollection)
        {
            if (serviceCollection == null)
            {
                throw new ArgumentNullException(nameof(serviceCollection));
            }

            serviceCollection.AddTransient<IValidator<AddTestRequestDto>, AddTestRequestDtoValidator>();
            serviceCollection.AddTransient<IValidator<UpdateTestRequestDto>, UpdateTestRequestDtoValidator>();

            serviceCollection.AddTransient<ISaveTestValidationService, SaveTestValidationService>();
            serviceCollection.AddTransient<IValidator<CreateModuleRequestDto>, CreateModuleRequestDtoValidator>();
            serviceCollection.AddTransient<IValidator<UpdateModuleRequestDto>, UpdateModuleRequestDtoValidator>();
            serviceCollection.AddTransient<IValidator<CreatePageRequestDto>, CreatePageRequestDtoValidator>();
            serviceCollection.AddTransient<IValidator<UpdatePageRequestDto>, UpdatePageRequestDtoValidator>();
            serviceCollection.AddTransient<ISaveModuleValidationService, SaveModuleValidationService>();
            serviceCollection.AddTransient<ISavePageValidationService, SavePageValidationService>();
            serviceCollection.AddTransient<ISaveSampleValidationService, SaveSampleValidationService>();

            serviceCollection.AddTransient<IValidator<CreateBranchRequestDto>, CreateBranchRequestDtoValidator>();
            serviceCollection.AddTransient<IValidator<UpdateBranchRequestDto>, UpdateBranchRequestDtoValidator>();

            serviceCollection.AddTransient<IValidator<CreateOrganisationRequestDto>, CreateOrganisationRequestDtoValidator>();
            serviceCollection.AddTransient<IValidator<UpdateOrganisationRequestDto>, UpdateOrganisationRequestDtoValidator>();

            serviceCollection.AddTransient<IValidator<AddCategoryRequestDto>, AddCategoryRequestDtoValidator>();
            serviceCollection.AddTransient<IValidator<UpdateCategoryRequestDto>, UpdateCategoryRequestDtoValidator>();

            serviceCollection.AddTransient<IValidator<AddGenderRequestDto>, AddGenderRequestDtoValidator>();
            serviceCollection.AddTransient<IValidator<UpdateGenderRequestDto>, UpdateGenderRequestDtoValidator>();

            serviceCollection.AddTransient<IValidator<CreateTestProfileRequestDto>, CreateTestProfileRequestDtoValidator>();
            serviceCollection.AddTransient<IValidator<UpdateTestProfileRequestDto>, UpdateTestProfileRequestDtoValidator>();
            serviceCollection.AddTransient<IValidator<CreateDepartmentRequestDto>, CreateDepartmentRequestDtoValidator>();
            serviceCollection.AddTransient<IValidator<UpdateDepartmentRequestDto>, UpdateDepartmentRequestDtoValidator>();

            serviceCollection.AddTransient<IValidator<CreateSampleTypeRequestDto>, CreateSampleTypeRequestDtoValidator>();
            serviceCollection.AddTransient<IValidator<CreateContainerTypeRequestDto>, CreateContainerTypeRequestDtoValidator>();
            serviceCollection.AddTransient<IValidator<CreateSampleRequestDto>, CreateSampleRequestDtoValidator>();
            serviceCollection.AddTransient<IValidator<UpdateSampleRequestDto>, UpdateSampleRequestDtoValidator>();

            serviceCollection.AddTransient<IValidator<CreatePatientRequestDto>, CreatePatientRequestDtoValidator>();
            serviceCollection.AddTransient<IValidator<CreateAppointmentRequestDto>, CreateAppointmentRequestDtoValidator>();
            serviceCollection.AddTransient<ICreatePatientValidationService, CreatePatientValidationService>();
        }
    }
}