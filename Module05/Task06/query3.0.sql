SELECT
	EmployeeID AS 'Seller',
	CustomerID AS 'Customer',
	Amount FROM (SELECT 
		EmployeeID, 
		CustomerID,
		COUNT(*) AS Amount, 
		GROUPING(EmployeeID) AS [Grouping]
		FROM Orders 
		GROUP BY EmployeeID, CustomerID WITH CUBE 
		) ord
ORDER BY Seller, Customer, Amount DESC