CREATE PROCEDURE [CRMLite].[GetLeadByEmail] @Email NVARCHAR(255)
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
WHERE [Email] = @Email
