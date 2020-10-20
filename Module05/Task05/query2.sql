SELECT COUNT(
	CASE
		WHEN [ShippedDate] IS NULL THEN 1
		ELSE NULL
	END) AS 'Number of orders'
FROM[dbo].[Orders]