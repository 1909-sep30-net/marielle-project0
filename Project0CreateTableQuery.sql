CREATE TABLE Customer (
	CustID INT NOT NULL PRIMARY KEY IDENTITY (1000, 1),
	FirstName NVARCHAR(20) NOT NULL,
	LastName NVARCHAR(20) NOT NULL,
	Street NVARCHAR(20) NOT NULL,
	City NVARCHAR(20) NOT NULL,
	State NVARCHAR(20) NOT NULL,
	ZipCode NVARCHAR(20) NOT NULL
);

