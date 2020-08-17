/****** Object:  Table [dbo].[appointment_test_profiles]    Script Date: 10/10/2019 6:53:21 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[appointment_test_profiles](
	[appointment_test_profiles_id] [bigint] IDENTITY(1,1) NOT NULL,
	[appointment_id] [bigint] NOT NULL,
	[test_profile_id] [bigint] NOT NULL,
	[modified_on] [datetime2](7) NULL,
 CONSTRAINT [appointment_test_profiles_pk] PRIMARY KEY NONCLUSTERED 
(
	[appointment_test_profiles_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[appointment_test_profiles]  WITH CHECK ADD  CONSTRAINT [appointment_test_profiles_appointments_appointment_id_fk] FOREIGN KEY([appointment_id])
REFERENCES [dbo].[appointments] ([appointment_id])
GO

ALTER TABLE [dbo].[appointment_test_profiles] CHECK CONSTRAINT [appointment_test_profiles_appointments_appointment_id_fk]
GO

ALTER TABLE [dbo].[appointment_test_profiles]  WITH CHECK ADD  CONSTRAINT [appointment_test_profiles_test_id_fk] FOREIGN KEY([test_profile_id])
REFERENCES [dbo].[tests] ([test_id])
GO

ALTER TABLE [dbo].[appointment_test_profiles] CHECK CONSTRAINT [appointment_test_profiles_test_id_fk]
GO

drop index samples_sample_type_id_uindex on samples
go

drop index samples_sample_id_uindex on samples
go



