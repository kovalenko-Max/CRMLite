CREATE PROCEDURE [CRMLite].[DeleteLeadRoleById] @ID UNIQUEIDENTIFIER,
	@RoleType INT
AS
DECLARE @RoleID INT

SET @RoleID = (
		SELECT [ID]
		FROM [CRMLite].[Roles]
		WHERE [Title] = @RoleType
		)

DELETE [CRMLite].[Lead_Role]
WHERE [CRMLite].[Lead_Role].LeadID = @ID
	AND [CRMLite].[Lead_Role].RoleID = @RoleID
