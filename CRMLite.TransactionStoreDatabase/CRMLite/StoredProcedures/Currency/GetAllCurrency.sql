CREATE PROCEDURE [CRMLite].[GetAllCurrency]
AS
SELECT cur.[ID],
	cur.[Title]
FROM [CRMLite].[Currencies] as cur
