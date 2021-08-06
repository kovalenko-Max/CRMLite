CREATE PROCEDURE [CRMLite].[CreateConfirmMessage] @LeadID UNIQUEIDENTIFIER,
	@ConfirmMessage NVARCHAR(20)
AS
INSERT INTO [CRMLite].[ConfirmMessage] (
	[LeadID],
	[ConfirmMessage]
	)
VALUES (
	@LeadID,
	@ConfirmMessage
	)
