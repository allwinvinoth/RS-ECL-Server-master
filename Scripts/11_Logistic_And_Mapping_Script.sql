
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[logistic_specimen](
	[logistic_specimen_id] [int] IDENTITY(1,1) NOT NULL,
	[logistic_id] [int] NULL,
	[container_type_id] [int] NULL,
	[specimen_count] [int] NULL,
 CONSTRAINT [PK_logistic_specimen_pk] PRIMARY KEY CLUSTERED 
(
	[logistic_specimen_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[logistic_types](
	[logistic_type_id] [int] IDENTITY(1,1) NOT NULL,
	[logistic_type] [nvarchar](255) NULL,
	[modified_on] [datetime2](7) NULL,
	[is_active] [bit] NULL,
 CONSTRAINT [PK_logistic_types] PRIMARY KEY CLUSTERED 
(
	[logistic_type_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[logistic_with_logistictype_mapping](
	[logistic_with_logistictype_mapping_id] [int] IDENTITY(1,1) NOT NULL,
	[logistic_id] [int] NULL,
	[logistic_type_id] [int] NULL,
 CONSTRAINT [PK_logistic_with_logistictype_mapping_pk] PRIMARY KEY CLUSTERED 
(
	[logistic_with_logistictype_mapping_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[logistics](
	[logistic_id] [int] IDENTITY(1,1) NOT NULL,
	[date] [datetime2](7) NOT NULL,
	[clinic] [nvarchar](255) NOT NULL,
	[called_by] [nvarchar](255) NOT NULL,
	[driver_id] [bigint] NOT NULL,
	[no_of_trfs] [int] NOT NULL,
	[temperature] [nvarchar](50) NOT NULL,
	[stat] [bit] NOT NULL,
	[remarks] [nvarchar](255) NOT NULL,
	[signature] [nvarchar](255) NOT NULL,
	[modified_on] [datetime2](7) NOT NULL,
	[is_active] [bit] NOT NULL,
 CONSTRAINT [PK_logistics] PRIMARY KEY CLUSTERED 
(
	[logistic_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[logistic_specimen]  WITH CHECK ADD  CONSTRAINT [FK_logistic_specimen_container_type_id_fk] FOREIGN KEY([container_type_id])
REFERENCES [dbo].[container_types] ([container_type_id])
GO
ALTER TABLE [dbo].[logistic_specimen] CHECK CONSTRAINT [FK_logistic_specimen_container_type_id_fk]
GO
ALTER TABLE [dbo].[logistic_specimen]  WITH CHECK ADD  CONSTRAINT [FK_logistic_specimen_logistic_id_fk] FOREIGN KEY([logistic_id])
REFERENCES [dbo].[logistics] ([logistic_id])
GO
ALTER TABLE [dbo].[logistic_specimen] CHECK CONSTRAINT [FK_logistic_specimen_logistic_id_fk]
GO
ALTER TABLE [dbo].[logistic_with_logistictype_mapping]  WITH CHECK ADD  CONSTRAINT [FK_logistic_with_logistictype_mapping_logistic_id_fk] FOREIGN KEY([logistic_id])
REFERENCES [dbo].[logistics] ([logistic_id])
GO
ALTER TABLE [dbo].[logistic_with_logistictype_mapping] CHECK CONSTRAINT [FK_logistic_with_logistictype_mapping_logistic_id_fk]
GO
ALTER TABLE [dbo].[logistic_with_logistictype_mapping]  WITH CHECK ADD  CONSTRAINT [FK_logistic_with_logistictype_mapping_logistictype_id_fk] FOREIGN KEY([logistic_type_id])
REFERENCES [dbo].[logistic_types] ([logistic_type_id])
GO
ALTER TABLE [dbo].[logistic_with_logistictype_mapping] CHECK CONSTRAINT [FK_logistic_with_logistictype_mapping_logistictype_id_fk]
GO
ALTER TABLE [dbo].[logistics]  WITH CHECK ADD  CONSTRAINT [FK_logistics_driver_id_fk] FOREIGN KEY([driver_id])
REFERENCES [dbo].[users] ([user_id])
GO
ALTER TABLE [dbo].[logistics] CHECK CONSTRAINT [FK_logistics_driver_id_fk]
GO
