CREATE PROCEDURE [CRMLite].[GetLeadByEmailAndPassword] @Email NVARCHAR(255),
	@Password NVARCHAR(255)
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
WHERE [Email] = @Email
	AND [Password] = @Password
