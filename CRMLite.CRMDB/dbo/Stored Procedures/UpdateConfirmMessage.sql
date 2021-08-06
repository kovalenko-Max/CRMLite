CREATE PROCEDURE [CRMLite].[UpdateConfirmMessage] @LeadID UNIQUEIDENTIFIER,
	@ConfimMessage NVARCHAR(20)
AS
UPDATE [CRMLite].[ConfirmMessage]
SET [ConfirmMessage] = @ConfimMessage
WHERE [LeadId] = @LeadID
