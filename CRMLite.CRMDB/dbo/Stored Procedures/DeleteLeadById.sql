CREATE PROCEDURE [CRMLite].[DeleteLeadByID] @ID UNIQUEIDENTIFIER
AS
DELETE [CRMLite].[Lead_Role]
WHERE [LeadID] = @ID

DELETE [CRMLite].[Leads]
WHERE [ID] = @ID

DELETE [CRMLite].[ConfirmMessage]
WHERE [LeadID] = @ID
