create table test_profiles
(
	test_profile_id BIGINT identity,
	name NVARCHAR(999) not null,
	outsource_id BIGINT,
	integration_code VARCHAR(99),
	minimum_selling_price MONEY,
	revenue_cap MONEY,
	profile_price MONEY,
	is_active BIT,
	modified_on DATETIME2
)
go

create unique index test_profiles_test_profile_id_uindex
	on test_profiles (test_profile_id)
go

alter table test_profiles
	add constraint test_profiles_pk
		primary key nonclustered (test_profile_id)
go

alter table tests
	add test_profile_id BIGINT
go

alter table tests
	add constraint tests_test_profiles_test_profile_id_fk
		foreign key (test_profile_id) references test_profiles
go

