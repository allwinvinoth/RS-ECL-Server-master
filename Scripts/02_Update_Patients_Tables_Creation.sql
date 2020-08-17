exec sp_rename 'patients.patient_id', user_id, 'COLUMN'
go

exec sp_rename 'patients', users, 'OBJECT'
go

alter table organisations alter column is_active bit not null
go