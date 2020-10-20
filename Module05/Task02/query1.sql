SELECT  [ContactName], [Country]
FROM [dbo].[Customers]
WHERE [Country] IN ('USA', 'Canada')
ORDER BY [ContactName], [Country]