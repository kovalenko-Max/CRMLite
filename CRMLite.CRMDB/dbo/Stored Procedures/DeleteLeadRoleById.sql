CREATE PROCEDURE [dbo].[DeleteLeadRoleById] @LeadId UNIQUEIDENTIFIER
AS
DELETE [CRMLite].[Lead_Role]
WHERE [CRMLite].[Lead_Role].LeadID = @LeadId
