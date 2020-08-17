CREATE TABLE appointment_status
(
    appointment_status_id INT IDENTITY
        CONSTRAINT PK_appointment_status
            PRIMARY KEY NONCLUSTERED,
    status         NVARCHAR(100) NOT NULL,
    is_active    BIT DEFAULT 1 NOT NULL,
    modified_on  DATETIME2     NOT NULL
)
GO

alter table appointments
	add appointment_status_id INT
go

alter table appointments
	add constraint appointments_appointment_status_id_fk
		foreign key (appointment_status_id) references appointment_status
go