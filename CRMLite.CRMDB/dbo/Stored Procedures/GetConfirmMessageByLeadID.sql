CREATE PROCEDURE [CRMLite].[GetConfirmMessageByLeadID] @LeadID UNIQUEIDENTIFIER
AS
SELECT [LeadID],
	[ConfirmMessage]
FROM [CRMLite].[ConfirmMessage]
WHERE [LeadID] = @LeadID
