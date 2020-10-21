SELECT
CONCAT(emp.FirstName, ' ', emp.Lastname) AS 'Name',
CONCAT(head.FirstName, ' ', head.Lastname) AS 'Supervisor'
FROM [dbo].[Employees] emp INNER JOIN
[dbo].[Employees] head ON emp.ReportsTo = head.EmployeeID