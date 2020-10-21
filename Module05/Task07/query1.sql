SELECT
	emp.FirstName + ' ' + emp.LastName AS 'Employee',
	ter.TerritoryDescription
FROM [dbo].[Employees] emp INNER JOIN
[dbo].[EmployeeTerritories] empter ON emp.EmployeeID = empter.EmployeeID INNER JOIN
[dbo].[Territories] ter ON ter.TerritoryID = empter.TerritoryID