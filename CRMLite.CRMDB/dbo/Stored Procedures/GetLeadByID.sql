CREATE PROCEDURE [CRMLite].[GetLeadByID] @ID UNIQUEIDENTIFIER
AS
SELECT [ID],
	[FirstName],
	[LastName],
	[Email],
	[PassportNumber],
	[Password],
	[TIN],
	[Status]
FROM [CRMLite].[Leads]
WHERE [ID] = @ID