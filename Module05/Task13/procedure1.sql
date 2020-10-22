USE [Northwind]  
GO

CREATE PROCEDURE GreatestOrders   
    @Year int,   
    @Records int   
AS   

SELECT TOP(@Records)
m.EmployeeName,
m.OrderID,
m.OrderSum
FROM (
	SELECT
		o.EmployeeName,
		MAX(o.OrderSum) OVER (PARTITION BY o.EmployeeName) AS MaxSum,
		o.OrderSum,
		o.OrderID
	FROM [dbo].[OrderWithSum] o
	WHERE YEAR(o.OrderDate) = @Year
) m
WHERE m.MaxSum = m.OrderSum
ORDER BY m.OrderSum DESC

GO