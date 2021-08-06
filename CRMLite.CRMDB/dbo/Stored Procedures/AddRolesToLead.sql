CREATE PROCEDURE [dbo].[AddRolesToLead] @LeadId UNIQUEIDENTIFIER,
	@RoleId UNIQUEIDENTIFIER
AS
INSERT INTO [CRMLite].[Lead_Role] (
	[LeadID],
	[RoleID]
	)
VALUES (
	@LeadID,
	@RoleId
	)
