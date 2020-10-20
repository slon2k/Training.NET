SELECT 
	(SELECT CONCAT([FirstName], ' ', [LastName]) 
	FROM [dbo].[Employees] 
	WHERE [Orders].[EmployeeID] = [Employees].[EmployeeID]) AS 'Employee',
	COUNT([OrderID]) AS 'Amount'
FROM [dbo].[Orders]
GROUP BY [EmployeeID]
ORDER BY 'Amount' DESC