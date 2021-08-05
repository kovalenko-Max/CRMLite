CREATE PROCEDURE [CRMLite].[CreateConfirmMessage] @LeadID UNIQUEIDENTIFIER,
	@ConfirmMessage NVARCHAR(20)
AS
INSERT INTO [CRMLite].[ConfirmMessage] (
	[LeadId],
	[ConfirmMessage]
	)
VALUES (
	@LeadID,
	@ConfirmMessage
	)
