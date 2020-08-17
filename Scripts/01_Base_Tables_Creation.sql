CREATE TABLE departments
(
    department_id INT IDENTITY,
    branch_id     INT           NOT NULL,
    name          NVARCHAR(255) NOT NULL,
    is_active     BIT DEFAULT 1 NOT NULL,
    modified_on   DATETIME2     NOT NULL
)
GO

EXEC sp_addextendedproperty 'MS_Description', 'Departments Table', 'SCHEMA', 'dbo', 'TABLE', 'departments'
GO

CREATE UNIQUE INDEX departments_department_id_uindex
    ON departments (department_id)
GO

CREATE TABLE gender
(
    gender_id   INT IDENTITY
        CONSTRAINT gender_pk
            PRIMARY KEY NONCLUSTERED,
    gender_name NVARCHAR(50)  NOT NULL,
    is_active   BIT DEFAULT 1 NOT NULL,
    modified_on DATETIME2     NOT NULL
)
GO

EXEC sp_addextendedproperty 'MS_Description', 'Gender Table', 'SCHEMA', 'dbo', 'TABLE', 'gender'
GO

CREATE UNIQUE INDEX genders_gender_id_uindex
    ON gender (gender_id)
GO

CREATE TABLE organisations
(
    organisation_id INT IDENTITY
        CONSTRAINT organisations_pk
            PRIMARY KEY NONCLUSTERED,
    name            NVARCHAR(255) NOT NULL,
    is_active       BIT DEFAULT 1,
    modified_on     DATETIME2     NOT NULL
)
GO

EXEC sp_addextendedproperty 'MS_Description', 'Organisations Table', 'SCHEMA', 'dbo', 'TABLE', 'organisations'
GO

CREATE TABLE branches
(
    branch_id       INT IDENTITY
        CONSTRAINT branches_pk
            PRIMARY KEY NONCLUSTERED,
    organisation_id INT           NOT NULL
        CONSTRAINT branches_organisations_organisation_id_fk
            REFERENCES organisations
            ON UPDATE CASCADE ON DELETE CASCADE,
    name            NVARCHAR(255) NOT NULL,
    modified_on     DATETIME2     NOT NULL,
    is_active       BIT DEFAULT 1 NOT NULL
)
GO

EXEC sp_addextendedproperty 'MS_Description', 'Branches Table', 'SCHEMA', 'dbo', 'TABLE', 'branches'
GO

CREATE UNIQUE INDEX branches_branch_id_uindex
    ON branches (branch_id)
GO

CREATE TABLE modules
(
    module_id       INT IDENTITY
        CONSTRAINT modules_pk
            PRIMARY KEY NONCLUSTERED,
    organisation_id INT           NOT NULL
        CONSTRAINT modules_organisations_organisation_id_fk
            REFERENCES organisations
            ON UPDATE CASCADE ON DELETE CASCADE,
    name            NVARCHAR(255) NOT NULL,
    is_active       BIT DEFAULT 1 NOT NULL,
    modified_on     DATETIME2     NOT NULL
)
GO

CREATE UNIQUE INDEX modules_module_id_uindex
    ON modules (module_id)
GO

CREATE UNIQUE INDEX organisations_organisation_id_uindex
    ON organisations (organisation_id)
GO

CREATE TABLE pages
(
    page_id         INT IDENTITY
        CONSTRAINT pages_pk
            PRIMARY KEY NONCLUSTERED,
    name            NVARCHAR(255) NOT NULL,
    is_active       BIT DEFAULT 1 NOT NULL,
    modified_on     DATETIME2     NOT NULL,
    organisation_id INT DEFAULT 0 NOT NULL
        CONSTRAINT pages_organisations_organisation_id_fk
            REFERENCES organisations
)
GO

EXEC sp_addextendedproperty 'MS_Description', 'Pages Table', 'SCHEMA', 'dbo', 'TABLE', 'pages'
GO

CREATE TABLE modules_pages_mapping
(
    modules_pages_mapping_id INT IDENTITY
        CONSTRAINT modules_pages_mapping_pk
            PRIMARY KEY NONCLUSTERED,
    module_id                INT           NOT NULL
        CONSTRAINT modules_pages_mapping_modules_module_id_fk
            REFERENCES modules,
    page_id                  INT           NOT NULL
        CONSTRAINT modules_pages_mapping_pages_page_id_fk
            REFERENCES pages,
    is_active                BIT DEFAULT 1 NOT NULL,
    modified_on              DATETIME2     NOT NULL
)
GO

CREATE UNIQUE INDEX modules_pages_mapping_modules_pages_mapping_id_uindex
    ON modules_pages_mapping (modules_pages_mapping_id)
GO

CREATE UNIQUE INDEX pages_page_id_uindex
    ON pages (page_id)
GO

CREATE TABLE tests_category
(
    category_id   BIGINT IDENTITY
        CONSTRAINT tests_category_pk
            PRIMARY KEY NONCLUSTERED,
    category_name NVARCHAR(255),
    modified_on   DATETIME2
)
GO

EXEC sp_addextendedproperty 'MS_Description', 'Tests Category Table', 'SCHEMA', 'dbo', 'TABLE', 'tests_category'
GO

CREATE TABLE tests
(
    test_id          BIGINT IDENTITY
        CONSTRAINT tests_pk
            PRIMARY KEY NONCLUSTERED,
    branch_id        BIGINT,
    department_id    BIGINT,
    category_id      BIGINT        NOT NULL
        CONSTRAINT tests_category_tests_category_id_fk
            REFERENCES tests_category,
    test_name        NVARCHAR(500) NOT NULL,
    test_code        VARCHAR(15),
    short_code       VARCHAR(15),
    integration_code VARCHAR(15),
    test_cost        MONEY,
    modified_on      DATETIME2
)
GO

EXEC sp_addextendedproperty 'MS_Description', 'Tests Table', 'SCHEMA', 'dbo', 'TABLE', 'tests'
GO

CREATE UNIQUE INDEX tests_test_id_uindex
    ON tests (test_id)
GO

CREATE UNIQUE INDEX tests_category_id_uindex
    ON tests_category (category_id)
GO

CREATE TABLE user_roles
(
    user_role_id INT IDENTITY
        CONSTRAINT user_type_pk
            PRIMARY KEY NONCLUSTERED,
    name         NVARCHAR(255) NOT NULL,
    is_active    BIT DEFAULT 1 NOT NULL,
    modified_on  DATETIME2     NOT NULL
)
GO

EXEC sp_addextendedproperty 'MS_Description', 'User Type Table', 'SCHEMA', 'dbo', 'TABLE', 'user_roles'
GO

CREATE TABLE patients
(
    patient_id               BIGINT IDENTITY
        CONSTRAINT patients_pk
            PRIMARY KEY NONCLUSTERED,
    name                     NVARCHAR(500) NOT NULL,
    primary_email            NVARCHAR(255),
    secondary_email          NVARCHAR(255),
    primary_contact_number   VARCHAR(15),
    secondary_contact_number VARCHAR(15),
    comments                 NVARCHAR(999),
    modified_on              DATETIME2,
    gender_id                INT
        CONSTRAINT patients_genders_gender_id_fk
            REFERENCES gender,
    is_active                BIT DEFAULT 1,
    user_role_id             INT
        CONSTRAINT patients_user_roles_user_role_id_fk
            REFERENCES user_roles
)
GO

EXEC sp_addextendedproperty 'MS_Description', 'Patients Table', 'SCHEMA', 'dbo', 'TABLE', 'patients'
GO

CREATE TABLE appointments
(
    appointment_id        BIGINT IDENTITY
        CONSTRAINT appointments_pk
            PRIMARY KEY NONCLUSTERED,
    patient_id            BIGINT    NOT NULL
        CONSTRAINT appointments_patients_patient_id_fk
            REFERENCES patients,
    appointment_date_from DATETIME2 NOT NULL,
    appointment_date_to   DATETIME2 NOT NULL,
    comments              NVARCHAR(999),
    modified_on           DATETIME2,
    doctor_id             BIGINT,
    patient_type          INT,
    referal               NVARCHAR(100),
    confirm_mode          INT
)
GO

EXEC sp_addextendedproperty 'MS_Description', 'Appointments Table', 'SCHEMA', 'dbo', 'TABLE', 'appointments'
GO

CREATE TABLE appointment_tests
(
    appointment_tests_id BIGINT IDENTITY
        CONSTRAINT appointment_tests_pk
            PRIMARY KEY NONCLUSTERED,
    appointment_id       BIGINT NOT NULL
        CONSTRAINT appointment_tests_appointments_appointment_id_fk
            REFERENCES appointments,
    test_id              BIGINT NOT NULL
        CONSTRAINT appointment_tests_tests_test_id_fk
            REFERENCES tests,
    modified_on          DATETIME2
)
GO

EXEC sp_addextendedproperty 'MS_Description', 'appointment_tests Table', 'SCHEMA', 'dbo', 'TABLE', 'appointment_tests'
GO

CREATE UNIQUE INDEX appointment_tests_id_uindex
    ON appointment_tests (appointment_tests_id)
GO

CREATE UNIQUE INDEX appointments_appointment_id_uindex
    ON appointments (appointment_id)
GO

CREATE UNIQUE INDEX patients_patient_id_uindex
    ON patients (patient_id)
GO

CREATE UNIQUE INDEX user_type_user_type_id_uindex
    ON user_roles (user_role_id)
GO

CREATE UNIQUE INDEX user_type_name_uindex
    ON user_roles (name)
GO

CREATE TABLE user_roles_with_modules_pages_mapping
(
    user_roles_with_modules_pages_mapping_id INT IDENTITY
        CONSTRAINT user_roles_with_modules_pages_mapping_pk
            PRIMARY KEY NONCLUSTERED,
    user_role_id                             INT           NOT NULL
        CONSTRAINT user_roles_with_modules_pages_mapping_user_roles_user_role_id_fk
            REFERENCES user_roles,
    modules_pages_mapping_id                 INT           NOT NULL
        CONSTRAINT user_roles_with_modules_pages_mapping_modules_pages_mapping_modules_pages_mapping_id_fk
            REFERENCES modules_pages_mapping,
    is_active                                BIT DEFAULT 1 NOT NULL,
    modified_on                              DATETIME2     NOT NULL
)
GO

CREATE UNIQUE INDEX user_roles_with_modules_pages_mapping_user_roles_with_modules_pages_mapping_id_uindex
    ON user_roles_with_modules_pages_mapping (user_roles_with_modules_pages_mapping_id)
GO