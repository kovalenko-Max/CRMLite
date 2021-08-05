CREATE PROCEDURE [CRMLite].[GetAllStocks]
AS
	SELECT 
	ID,
	Title,
	IsDividend

	from [CRMLite].[Stock]