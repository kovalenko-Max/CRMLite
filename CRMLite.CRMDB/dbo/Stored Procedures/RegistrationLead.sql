CREATE PROCEDURE [CRMLite].[RegistrationLead]
	@LeadID UNIQUEIDENTIFIER,
	@RoleID UNIQUEIDENTIFIER,
	@LastName NVARCHAR(255),
	@FirstName NVARCHAR(255),
	@PassportNumber NVARCHAR(8),
	@TIN NVARCHAR(12),
	@Email NVARCHAR(255),
	@Password NVARCHAR(255),
	@Status NVARCHAR(255)
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
	@LeadID,
	@LastName,
	@FirstName,
	@PassportNumber,
	@TIN,
	@Email,
	@Password,
	@Status
	)

INSERT INTO [CRMLite].[Lead_Role] (
	[LeadID],
	[RoleID]
)
VALUES(
	@LeadID,
	@RoleID
)