CREATE PROCEDURE [CRMLite].[UpdateLead] @Id UNIQUEIDENTIFIER
	,@Lastname NVARCHAR(255)
	,@Firstname NVARCHAR(255)
	,@PasportNumber NVARCHAR(8)
	,@TIN NVARCHAR(12)
	,@Email NVARCHAR(255)
	,@Password NVARCHAR(255)
	,@Role NVARCHAR(255)
AS
UPDATE [CRMLite].[Leads]
SET [Id] = @Id
	,[Lastname] = @Lastname
	,[Firstname] = @Firstname
	,[PasportNumber] = @PasportNumber
	,[TIN] = @TIN
	,[Email] = @Email
	,[Password] = @Password
	,[Role] = @Role
WHERE [Id] = @Id