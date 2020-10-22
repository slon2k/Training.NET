CREATE FUNCTION dbo.NumberOfSubordinates(@EmployeeID int)  
RETURNS int   
AS     
BEGIN  
    DECLARE @ret int;  
    SELECT @ret = COUNT(*)   
    FROM [dbo].[Employees] e   
    WHERE e.ReportsTo = @EmployeeID
     IF (@ret IS NULL)   
        SET @ret = 0;  
    RETURN @ret;  
END; 