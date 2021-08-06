CREATE PROCEDURE [CRMLite].[UpdateLead] @ID UNIQUEIDENTIFIER,
	@LastName NVARCHAR(255),
	@FirstName NVARCHAR(255),
	@PassportNumber NVARCHAR(8),
	@TIN NVARCHAR(12),
	@Email NVARCHAR(255),
	@Password NVARCHAR(255),
	@Status NVARCHAR(255)
AS
UPDATE [CRMLite].[Leads]
SET [Id] = @Id,
	[Lastname] = @Lastname,
	[Firstname] = @Firstname,
	[PassportNumber] = @PassportNumber,
	[TIN] = @TIN,
	[Email] = @Email,
	[Password] = @Password,
	[Status] = @Status
WHERE [Id] = @Id
