SELECT  [ContactName], [Country]
FROM [dbo].[Customers]
WHERE [Country] NOT IN ('USA', 'Canada')
ORDER BY [ContactName]