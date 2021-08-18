CREATE PROCEDURE [CRMLite].[DeleteConfirmMessageByLeadID] @LeadID UNIQUEIDENTIFIER
AS
DELETE [CRMLite].[ConfirmMessage]
WHERE [LeadID] = @LeadID
