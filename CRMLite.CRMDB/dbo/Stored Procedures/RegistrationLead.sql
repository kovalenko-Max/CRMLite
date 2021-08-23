CREATE PROCEDURE [CRMLite].[RegistrationLead]
	@ID UNIQUEIDENTIFIER,
	@LastName NVARCHAR(255),
	@FirstName NVARCHAR(255),
	@PassportNumber NVARCHAR(8),
	@TIN NVARCHAR(12),
	@Email NVARCHAR(255),
	@Password NVARCHAR(255),
	@StatusType NVARCHAR(255)
AS
INSERT INTO [CRMLite].[Leads] (
	[ID],
	[LastName],
	[FirstName],
	[PassportNumber],
	[TIN],
	[Email],
	[Password],
	[Status]
	)
OUTPUT inserted.Id
VALUES (
	@ID,
	@LastName,
	@FirstName,
	@PassportNumber,
	@TIN,
	@Email,
	@Password,
	@StatusType
	)