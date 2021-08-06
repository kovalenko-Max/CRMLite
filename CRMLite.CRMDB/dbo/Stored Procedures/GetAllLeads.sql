CREATE PROCEDURE [CRMLite].[GetAllLeads]
AS
SELECT [Leads].[ID],
	[FirstName],
	[LastName],
	[Email],
	[PassportNumber],
	[Password],
	[TIN],
	[Status],
	[Roles].[Title] As [Role]
FROM [CRMLite].[Leads]
INNER JOIN [CRMLite].[Lead_Role] ON [Leads].[ID] = [Lead_Role].[LeadID]
INNER JOIN [CRMLite].[Roles] ON [Lead_Role].[RoleID] = [Roles].[ID]