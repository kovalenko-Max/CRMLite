CREATE PROCEDURE [CRMLite].[DeleteLeadRoleById] @ID UNIQUEIDENTIFIER,
	@RoleID INT
AS
DELETE [CRMLite].[Lead_Role]
WHERE [CRMLite].[Lead_Role].LeadID = @ID
	AND [CRMLite].[Lead_Role].RoleID = @RoleID
