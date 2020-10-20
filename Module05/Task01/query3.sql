SELECT [OrderID] As 'Order Number',
CASE
	WHEN ShippedDate IS NOT NULL THEN CONVERT(char(25), ShippedDate, 121)
	ELSE 'Not shipped'
END AS 'Shipped date'
FROM [dbo].[Orders]
WHERE ShippedDate IS NULL OR ShippedDate >= '1998-5-6'