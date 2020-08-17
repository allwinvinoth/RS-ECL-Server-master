Alter Table [dbo].[home_collection]
Drop constraint [FK_home_collection_payment_types_id_fk];
Go

Drop Table [dbo].[payment_types]
Go

Alter Table [dbo].[home_collection]
Drop Column 
[phlebotomy_cost],
[loyalty_card_no],
[discount],
[total_cost],
[payment_type_id];
Go

Alter Table [dbo].[home_collection]
Add 
patient_name [nvarchar](500) NULL,
mobile_number [varchar](15) NULL,
phone_number [varchar](15) NULL,
email [nvarchar](255) NULL,
date_of_birth [datetime2](7) NULL,
gender_id [int] NULL,
referral_organization [nvarchar](255) NULL,
referral_doctor_id [bigint] NULL,
postal_code [nvarchar](50) NULL,
comment [nvarchar](255) NULL
Go

alter table home_collection
	add constraint FK_home_collection_gender_id
		foreign key (gender_id) references gender ([gender_id])
go

alter table home_collection
	add constraint FK_home_collection_referral_doctor_id
		foreign key (referral_doctor_id) references users ([user_id])
go