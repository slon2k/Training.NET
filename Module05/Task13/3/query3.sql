WITH RecursiveQuery(EmployeeID, ReportsTo, LastName)
AS
(
SELECT EmployeeID, ReportsTo, LastName
FROM Employees e
WHERE e.EmployeeID = 2
UNION ALL
SELECT e.EmployeeID, e.ReportsTo, e.LastName
FROM Employees e
JOIN RecursiveQuery rec ON e.ReportsTo = rec.EmployeeID
)
SELECT EmployeeID, ReportsTo, LastName
FROM RecursiveQuery