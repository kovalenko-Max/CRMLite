CREATE PROCEDURE [CRMLite].[CreateRole] @RoleType INT
AS
INSERT INTO [CRMLite].[Roles] ([Title])
VALUES (@RoleType)
