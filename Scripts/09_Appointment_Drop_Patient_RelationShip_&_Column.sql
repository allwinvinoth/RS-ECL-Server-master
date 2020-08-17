Alter Table [dbo].[appointments]
Drop constraint [appointments_patients_patient_id_fk];
Go
Alter Table [dbo].[appointments]
Drop Column [patient_id];
Go
Alter Table [dbo].[appointments]
Add 
name nvarchar(255),
email nvarchar(255),
date_of_birth datetime2(7),
phone_number varchar(15),
mobile_number varchar(15);
Go