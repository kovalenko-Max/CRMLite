CREATE PROCEDURE [CRMLite].[GetAllCurrency]
AS
SELECT cur.[ID],
	cur.[Name]
FROM [CRMLite].[Currency] as cur
