CREATE PROCEDURE [CRMLite].[PaginateLeads] @StartItem INT,
	@CountItems INT
AS
SELECT [Leads].[ID],
	[FirstName],
	[LastName],
	[Email],
	[PassportNumber],
	[Password],
	[TIN],
	[Status]
FROM [CRMLite].[Leads]
ORDER BY ID OFFSET @StartItem ROWS

FETCH NEXT @CountItems ROWS ONLY
