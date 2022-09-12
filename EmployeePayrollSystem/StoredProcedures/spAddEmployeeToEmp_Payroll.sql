CREATE PROCEDURE spAddNewEmployee
	@employee_name varchar(50),
	@start_date date,
	@gender char(1),
	@phone_number varchar(15),
	@address varchar(50),
	@department_name varchar(50),
	@basic_pay float
AS
BEGIN
SET XACT_ABORT ON
	BEGIN TRY
		BEGIN TRANSACTION
			INSERT INTO employee_payroll(name,start,gender,phone_number,address,department,basic_pay)
			VALUES
			(@employee_name,@start_date,@gender,@phone_number,@address,@department_name,@basic_pay);
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		PRINT (ERROR_MESSAGE()); 
		ROLLBACK TRANSACTION
	END CATCH
END