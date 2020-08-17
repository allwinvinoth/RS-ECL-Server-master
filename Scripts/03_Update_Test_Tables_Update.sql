alter table tests drop column branch_id
go

exec sp_rename 'tests.test_name', name, 'COLUMN'
go

alter table tests alter column name nvarchar(999) not null
go

alter table tests alter column test_code NVARCHAR(99) null
go

exec sp_rename 'tests.short_code', short_text, 'COLUMN'
go

alter table tests alter column short_text varchar(99) null
go

alter table tests alter column integration_code varchar(99) null
go

exec sp_rename 'tests.test_cost', minimum_selling_price, 'COLUMN'
go

alter table tests drop column modified_on
go

alter table tests
	add is_report_masked BIT default 0 not null
go

alter table tests
    add revenue_cap MONEY
go

alter table tests
    add target_tat_days int
go

alter table tests
    add target_tat_hours int
go

alter table tests
    add target_tat_minute int
go

alter table tests
    add description TEXT
go

alter table tests
    add price MONEY
go

alter table tests
    add price2 MONEY
go

alter table tests
    add cost MONEY null
go

alter table tests
    add is_auto_dispatch BIT default 0 not null
go

alter table tests
    add is_billonly_test BIT default 0 not null
go

alter table tests
	add is_nabl_test BIT default 0 not null
go

alter table tests
	add is_na BIT default 0 not null
go

alter table tests
	add is_print_priority_na BIT default 0 not null
go

alter table tests
	add is_outsource_test BIT default 0 not null
go

alter table tests
	add is_discard_discount BIT default 0 not null
go

alter table tests
	add is_cap BIT default 0 not null
go

alter table tests
	add is_no_report_to_patient BIT default 0 not null
go

alter table tests
	add is_active BIT default 1 not null
go

alter table tests
	add modified_on DATETIME2
go

alter table tests drop constraint tests_category_tests_category_id_fk
go

alter table tests alter column department_id INT null
go

alter table tests
	add constraint tests_departments_department_id_fk
		foreign key (department_id) references departments (department_id)
go

alter table tests_category alter column category_name nvarchar(999) null
go

alter table tests_category
	add is_active BIT default 1 not null
go

--alter table tests
--	add is_report_masked BIT default 0 not null
--go

--exec sp_rename 'tests.target_tat_minute', target_tat_minutes, 'COLUMN'
--go

alter table tests alter column category_id INT not null
go

--exec sp_rename 'tests_category.category_name', name, 'COLUMN'
--go