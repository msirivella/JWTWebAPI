
Create Table Employee
(
	ID	Int Identity(1,1) Primary Key,
	Name NVarchar(100),
	EmployeeNumber Int,
	Role NVarchar(100),
	Active int
)
GO
Create Table Attendance
(
	EmployeeID Int Not null FOREIGN KEY REFERENCES Employee(ID),
	ShiftDate	NVarchar(20),
	InTime	NVarchar(50),
	OutTime	NVarchar(50),
	Status	NVarchar(50)
)
GO
Create Table OT_Data
(
	EmployeeID Int Not null FOREIGN KEY REFERENCES Employee(ID),
	ShiftDate	NVarchar(20),
	NormalOT	Int,
	PremiumOT	Int
)
GO