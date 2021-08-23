CREATE PROCEDURE [CRMLite].[GetAllRolesById] @ID UNIQUEIDENTIFIER
AS
SELECT [CRMLite].[Roles].Title
FROM [CRMLite].[Lead_Role]
INNER JOIN [CRMLite].[Roles] ON [CRMLite].[Roles].ID = [CRMLite].[Lead_Role].RoleID
WHERE [CRMLite].[Lead_Role].LeadID = @ID
