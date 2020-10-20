SELECT YEAR([OrderDate]) AS 'Year', COUNT([CustomerID]) AS 'Orders number'
  FROM [dbo].[Orders]
  GROUP BY YEAR([OrderDate])