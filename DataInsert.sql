﻿Insert Into Employee(Name, EmployeeNumber, Role, Active)
Values('Dynis', 410333, 'QC Operator', 1)
Insert Into Employee(Name, EmployeeNumber, Role, Active)
Values('Balaji', 434343, 'RTG', 1)
Insert Into Employee(Name, EmployeeNumber, Role, Active)
Values('Albert', 543243, 'RMG', 1)
Insert Into Employee(Name, EmployeeNumber, Role, Active)
Values('Raj', 343433, 'ITV', 0)

Insert into Attendance(EmployeeID, ShiftDate, InTime, OutTime, Status)
Values(1, '1-Jan-2020', '01-Jan-2020 07:00', '01-Jan-2020 19:00', 'On Time')
Insert into Attendance(EmployeeID, ShiftDate, InTime, OutTime, Status)
Values(2, '1-Jan-2020', '', '', 'Absent')
Insert into Attendance(EmployeeID, ShiftDate, InTime, OutTime, Status)
Values(3, '1-Jan-2020', '01-Jan-2020 19:00', '02-Jan-2020 07:00', 'On Time')
Insert into Attendance(EmployeeID, ShiftDate, InTime, OutTime, Status)
Values(3, '1-Jan-2020', '01-Jan-2020 07:00', '01-Jan-2020 19:00', 'On Time')

Insert Into OT_Data(EmployeeID, ShiftDate, NormalOT, PremiumOT)
Values(1, '1-Jan-2020', 0, 12)
Insert Into OT_Data(EmployeeID, ShiftDate, NormalOT, PremiumOT)
Values(3, '1-Jan-2020', 0, 12)
Insert Into OT_Data(EmployeeID, ShiftDate, NormalOT, PremiumOT)
Values(3, '3-Jan-2020', 4, 0)