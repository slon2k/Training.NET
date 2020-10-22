SELECT 
  o.OrderID,
  OrderSum,
  EmployeeID
FROM (
  SELECT
    o.OrderID,
    SUM( ROUND(od.UnitPrice * (1 - od.Discount) * od.Quantity, 2) ) AS OrderSum
  FROM [dbo].[Orders] o INNER JOIN
  [dbo].[Order Details] od ON o.OrderID = od.OrderID
  GROUP BY o.OrderID
) d INNER JOIN
[dbo].[Orders] o ON o.OrderID = d.OrderID
WHERE YEAR(o.OrderDate) = 1997