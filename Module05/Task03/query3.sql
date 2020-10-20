SELECT [CustomerID], [Country]
FROM [dbo].[Customers]
WHERE LEFT([Country], 1) >= 'B' AND LEFT([Country], 1) <= 'G'
ORDER BY [Country]