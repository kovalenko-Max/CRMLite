CREATE PROCEDURE [CRMLite].[GetRoleID] @TypeRole INT
AS
SELECT [CRMLite].[Roles].ID
FROM [CRMLite].[Roles]
WHERE [CRMLite].[Roles].Title = @TypeRole

