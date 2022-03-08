CREATE TABLE Employee (
	Id bigint PRIMARY KEY IDENTITY(1,1) NOT NULL,
	FirstName varchar(50) NOT NULL,
	LastName varchar(50) NOT NULL,
	AnnualSalary Decimal(8,2) NOT NULL,
	PayCheckDeduction Decimal(5,2) NOT NULL,
	PayCheckAmount Decimal(8,2) NOT NULL
)
GO

CREATE TABLE [Dependent] (
	Id bigint PRIMARY KEY IDENTITY(1,1) NOT NULL,
	FirstName varchar(50) NOT NULL,
	LastName varchar(50) NOT NULL,
	EmployeeId bigint NOT NULL
)
GO

ALTER TABLE [Dependent]
ADD CONSTRAINT FK_Dependent_Employee FOREIGN KEY (EmployeeId)
REFERENCES Employee(Id)
GO