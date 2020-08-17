Drop Table appointment_test_profiles;
Go

Drop Table appointment_tests;
Go

sp_rename 'appointments.comments', comment, 'COLUMN';
Go

sp_rename 'appointments.phone_number', primary_phone_number, 'COLUMN';
Go

sp_rename 'appointments.mobile_number', secondary_phone_number, 'COLUMN';
Go

Alter Table appointments
Drop Column doctor_id,patient_type,referal,confirm_mode;
Go

