CREATE PROCEDURE [CRMLite].[GetAllOperationTypes]
AS
SELECT opt.[ID],
	opt.[Type]
FROM [CRMLite].[OperationTypes] AS opt
