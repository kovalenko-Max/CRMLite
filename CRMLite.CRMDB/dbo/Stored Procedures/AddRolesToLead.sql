CREATE PROCEDURE [CRMLite].[AddRoleToLead] @LeadID UNIQUEIDENTIFIER,
	@RoleID int
AS
INSERT INTO [CRMLite].[Lead_Role] (
	[LeadID],
	[RoleID]
	)
VALUES (
	@LeadID,
	@RoleID
	)
