SELECT [OrderID], [ShippedDate],
CASE
    WHEN [ShippedDate] IS NULL THEN 'Not shipped'
END AS 'Shipped date'
FROM [dbo].[Orders]
WHERE  [ShippedDate] IS NULL