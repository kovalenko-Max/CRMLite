CREATE PROCEDURE [CRMLite].[DeleteConfirmMessage] @LeadID UNIQUEIDENTIFIER
AS
DELETE [CRMLite].[ConfirmMessage]
WHERE [LeadID] = @LeadID
