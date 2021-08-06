CREATE PROCEDURE [CRMLite].[GetLeadByEmail] @Email NVARCHAR(255)
AS
SELECT Leads.Id,
	Leads.Firstname,
	Leads.Lastname,
	Leads.Email,
	Leads.PasportNumber,
	Leads.Password,
	Leads.TIN,
	Leads.ROLE
FROM [CRMLite].[Leads]
WHERE [Email] = @Email
