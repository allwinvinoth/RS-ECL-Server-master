CREATE TABLE sample_types
(
    sample_type_id   INT IDENTITY
        CONSTRAINT sample_type_pk
            PRIMARY KEY NONCLUSTERED,
    sample_type_name NVARCHAR(50)  NOT NULL,
    is_active   BIT DEFAULT 1 NOT NULL,
    modified_on DATETIME2     NOT NULL
)
GO

EXEC sp_addextendedproperty 'MS_Description', 'Sample Type Table', 'SCHEMA', 'dbo', 'TABLE', 'sample_types'
GO

CREATE UNIQUE INDEX samples_sample_type_id_uindex
    ON sample_types (sample_type_id )
GO

CREATE TABLE container_types
(
    container_type_id   INT IDENTITY
        CONSTRAINT container_type_pk
            PRIMARY KEY NONCLUSTERED,
    container_type_name NVARCHAR(50)  NOT NULL,
    is_active   BIT DEFAULT 1 NOT NULL,
    modified_on DATETIME2     NOT NULL
)
GO

EXEC sp_addextendedproperty 'MS_Description', 'Container Type Table', 'SCHEMA', 'dbo', 'TABLE', 'container_types'
GO

CREATE UNIQUE INDEX container_container_type_id_uindex
    ON container_types (container_type_id)
GO

CREATE TABLE samples
(
    sample_id INT IDENTITY
        CONSTRAINT samples_pk
            PRIMARY KEY NONCLUSTERED,
	name            NVARCHAR(255) NOT NULL,
	accession_id                INT           NOT NULL,
    sample_type_id                INT           NOT NULL
        CONSTRAINT samples_sample_type_id_fk
            REFERENCES sample_types,
    container_type_id                  INT           NOT NULL
        CONSTRAINT samples_container_type_id_fk
            REFERENCES container_types,
			description            NVARCHAR(255),
			instruction            NVARCHAR(255),
			is_prefix       BIT DEFAULT 1 NOT NULL,
			is_active   BIT DEFAULT 1 NOT NULL,
    modified_on              DATETIME2     NOT NULL
)
GO

CREATE UNIQUE INDEX samples_sample_type_id_uindex
    ON samples (sample_type_id )
GO
CREATE UNIQUE INDEX samples_container_type_id_uindex
    ON container_types (container_type_id )
GO

CREATE UNIQUE INDEX samples_sample_id_uindex
    ON samples (sample_id)
GO