CREATE PROCEDURE [CRMLite].[GetAllCurrencies]
AS
SELECT 
	ID,
	Code,
	Title
FROM [CRMLite].[Currencies]
