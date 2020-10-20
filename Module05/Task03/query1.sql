SELECT DISTINCT [OrderID]
FROM [dbo].[Order Details]
WHERE [Quantity] BETWEEN 3 AND 10
ORDER BY [OrderID]