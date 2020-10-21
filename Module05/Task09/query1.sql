SELECT DISTINCT
s.CompanyName
FROM [dbo].[Suppliers] s LEFT JOIN
[dbo].[Products] p ON p.SupplierID = s.SupplierID
WHERE p.UnitsInStock = 0 OR p.UnitsInStock IS NULL;