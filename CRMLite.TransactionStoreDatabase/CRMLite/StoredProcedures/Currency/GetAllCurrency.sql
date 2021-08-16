CREATE PROCEDURE [CRMLite].[GetAllCurrency]
AS
SELECT 
	ID,
	Code,
	Title
FROM [CRMLite].[Currencies]
