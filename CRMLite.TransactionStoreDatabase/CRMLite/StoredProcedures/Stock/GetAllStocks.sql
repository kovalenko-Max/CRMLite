CREATE PROCEDURE [CRMLite].[GetAllStocks]
AS
SELECT ID,
	Title,
	IsDividend
FROM [CRMLite].[Stock]