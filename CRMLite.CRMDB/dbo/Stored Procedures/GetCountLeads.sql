CREATE PROCEDURE [CRMLite].[GetCountLeads]
AS
SELECT COUNT([CRMLite].[Leads].[ID])
FROM [CRMLite].[Leads]
