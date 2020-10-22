USE [Northwind]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[OrderWithSum]
AS
SELECT
	o.OrderID, 
	d.OrderSum, 
	o.EmployeeID, 
	dbo.Employees.FirstName + ' ' + dbo.Employees.LastName AS EmployeeName, 
	o.OrderDate
FROM            
	(SELECT	o.OrderID, SUM(ROUND(od.UnitPrice * (1 - od.Discount) * od.Quantity, 2)) AS OrderSum
  FROM            
		dbo.Orders AS o INNER JOIN
    dbo.[Order Details] AS od ON o.OrderID = od.OrderID
  GROUP BY o.OrderID) AS d INNER JOIN
    dbo.Orders AS o ON o.OrderID = d.OrderID INNER JOIN
    dbo.Employees ON o.EmployeeID = dbo.Employees.EmployeeID
GO