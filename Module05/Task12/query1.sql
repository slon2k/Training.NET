SELECT DISTINCT
LEFT(e.LastName, 1) AS Letter
FROM [dbo].[Employees] e
ORDER BY Letter