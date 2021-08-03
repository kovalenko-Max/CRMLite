CREATE PROCEDURE [CRMLite].[RegistrationLead] @Id UNIQUEIDENTIFIER
	,@Lastname NVARCHAR(255)
	,@Firstname NVARCHAR(255)
	,@PasportNumber NVARCHAR(8)
	,@TIN NVARCHAR(12)
	,@Email NVARCHAR(255)
	,@Password NVARCHAR(255)
	,@Role NVARCHAR(255)
AS
INSERT INTO [CRMLite].[Leads] (
	[Id]
	,[Lastname]
	,[Firstname]
	,[PasportNumber]
	,[TIN]
	,[Email]
	,[Password]
	,[Role]
	)
OUTPUT inserted.Id
VALUES (
	@Id
	,@Lastname
	,@Firstname
	,@PasportNumber
	,@TIN
	,@Email
	,@Password
	,@Role
	)