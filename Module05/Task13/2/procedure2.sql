USE [Northwind]

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ShippedOrdersDiff]   
    @Delay int
AS   

BEGIN
	SET NOCOUNT ON;

	SELECT
		o.OrderID,
		o.OrderDate,
		o.ShippedDate,
		DATEDIFF(day, o.OrderDate, o.ShippedDate)  AS ShippedDelay 
	FROM [dbo].[Orders] o
	WHERE DATEDIFF(day, o.OrderDate, o.ShippedDate) > @Delay OR o.ShippedDate IS NULL
END
GO
