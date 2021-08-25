CREATE PROCEDURE [CRMLite].[GetAllStocks]
AS
SELECT ID,
	Title,
	Code,
	IsDividend
FROM [CRMLite].[Stock]