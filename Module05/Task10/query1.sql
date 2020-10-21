SELECT
e.FirstName + ' ' + e.LastName AS 'Top Employees'
FROM [dbo].[Employees] e
WHERE (SELECT COUNT(*) FROM [dbo].[Orders] o WHERE o.EmployeeID = e.EmployeeID)  > 100