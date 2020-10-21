SELECT
c.CompanyName,
COUNT(o.OrderID) AS 'Orders'
FROM [dbo].[Customers] c LEFT JOIN
[dbo].[Orders] o ON o.CustomerID = c.CustomerID
GROUP BY c.CompanyName
ORDER BY 'Orders'