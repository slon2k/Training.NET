WITH OrderSum AS (
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
)

SELECT TOP(5)
m.EmployeeName,
m.OrderID,
m.OrderSum
FROM (
	SELECT
		o.EmployeeName,
		MAX(o.OrderSum) OVER (PARTITION BY o.EmployeeName) AS MaxSum,
		o.OrderSum,
		o.OrderID
	FROM OrderSum o
	WHERE YEAR(o.OrderDate) = 1997
) m
WHERE m.MaxSum = m.OrderSum
ORDER BY m.OrderSum DESC