ALTER TABLE appointments
ADD is_active bit;
GO

ALTER TABLE appointment_tests
ADD is_active bit;
GO

ALTER TABLE appointment_test_profiles
ADD is_active bit;
GO