SELECT CONVERT(money, ROUND(SUM(([UnitPrice] - [Discount]) * [Quantity]), 2), 1) AS 'Totals'
FROM [dbo].[Order Details]