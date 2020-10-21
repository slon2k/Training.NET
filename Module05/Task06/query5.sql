SELECT DISTINCT
cust1.CustomerID,
cust1.City
FROM [dbo].[Customers] cust1 INNER JOIN
[dbo].[Customers] cust2 ON cust1.City = cust2.City
WHERE cust1.CustomerID != cust2.CustomerID

-- For checking 
SELECT
City,
COUNT(City) AS 'Count'
FROM [dbo].[Customers]
GROUP BY City
HAVING COUNT(City) > 1
ORDER BY City


