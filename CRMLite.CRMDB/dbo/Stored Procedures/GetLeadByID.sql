CREATE PROCEDURE [CRMLite].[GetLeadByID] @ID UNIQUEIDENTIFIER
AS
SELECT [ID],
	[Firstname],
	[Lastname],
	[Email],
	[PassportNumber],
	[Password],
	[TIN],
	[Status]
FROM [CRMLite].[Leads]
WHERE [ID] = @ID