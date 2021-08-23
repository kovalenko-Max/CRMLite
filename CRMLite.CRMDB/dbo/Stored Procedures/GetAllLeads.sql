CREATE PROCEDURE [CRMLite].[GetAllLeads]
AS
SELECT [Leads].[ID],
	[FirstName],
	[LastName],
	[Email],
	[PassportNumber],
	[Password],
	[TIN],
	[Status]
FROM [CRMLite].[Leads]