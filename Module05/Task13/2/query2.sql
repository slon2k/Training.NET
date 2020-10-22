SELECT
  o.OrderID,
  o.OrderDate,
  o.ShippedDate,
  DATEDIFF(day, o.OrderDate, o.ShippedDate)  AS ShippedDelay 
FROM [dbo].[Orders] o
WHERE DATEDIFF(day, o.OrderDate, o.ShippedDate) > 20 OR o.ShippedDate IS NULL