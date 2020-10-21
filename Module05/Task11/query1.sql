SELECT
	c.CompanyName
FROM [dbo].[Customers] c
WHERE NOT EXISTS (SELECT o.OrderID FROM [dbo].[Orders] o WHERE o.CustomerID = c.CustomerID) 