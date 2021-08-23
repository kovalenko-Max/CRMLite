CREATE PROCEDURE [CRMLite].[AddRoleToLead] @LeadID UNIQUEIDENTIFIER,
	@RoleType INT
AS
DECLARE @RoleID INT

SET @RoleID = (
		SELECT [ID]
		FROM [CRMLite].[Roles]
		WHERE [Title] = @RoleType
		)

INSERT INTO [CRMLite].[Lead_Role] (
	[LeadID],
	[RoleID]
	)
VALUES (
	@LeadID,
	@RoleID
	)
