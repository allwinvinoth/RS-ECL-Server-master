
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[home_collection](
	[home_collection_id] [int] IDENTITY(1,1) NOT NULL,
	[scheduled_date] [datetime2](7) NOT NULL,
	[country] [nvarchar](255) NULL,
	[city] [nvarchar](255) NULL,
	[area] [nvarchar](255) NULL,
	[phlebotomy_cost] [int] NULL,
	[loyalty_card_no] [int] NULL,
	[discount] [int] NULL,
	[total_cost] [money] NULL,
	[payment_type_id] [int] NOT NULL,
	[modified_on] [datetime2](7) NULL,
	[is_active] [bit] NOT NULL,
 CONSTRAINT [PK_home_collection] PRIMARY KEY CLUSTERED 
(
	[home_collection_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[payment_types](
	[payment_type_id] [int] IDENTITY(1,1) NOT NULL,
	[payment_option] [nvarchar](255) NULL,
	[modified_on] [datetime2](7) NULL,
	[is_active] [bit] NOT NULL,
 CONSTRAINT [PK_payment_types] PRIMARY KEY CLUSTERED 
(
	[payment_type_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[home_collection]  WITH CHECK ADD  CONSTRAINT [FK_home_collection_payment_types_id_fk] FOREIGN KEY([payment_type_id])
REFERENCES [dbo].[payment_types] ([payment_type_id])
GO
ALTER TABLE [dbo].[home_collection] CHECK CONSTRAINT [FK_home_collection_payment_types_id_fk]
GO
