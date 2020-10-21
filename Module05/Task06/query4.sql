SELECT
	CompanyName AS 'Customer',
	CONCAT(emp.FirstName, ' ', emp.Lastname) AS Seller,
	cust.City
FROM [dbo].[Customers] cust INNER JOIN
[dbo].[Employees] emp ON emp.City = cust.City
ORDER BY cust.City, Seller