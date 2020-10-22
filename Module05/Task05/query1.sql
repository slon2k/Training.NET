SELECT CONVERT(money, ROUND(SUM([UnitPrice]*(1 - [Discount]) * [Quantity]), 2), 1) AS 'Totals'
FROM [dbo].[Order Details]