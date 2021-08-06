CREATE PROCEDURE [dbo].[GetAllLeads]
AS
SELECT Leads.Id
	,Leads.Firstname
	,Leads.Lastname
	,Leads.Email
	,Leads.PasportNumber
	,Leads.Password
	,Leads.TIN
	,Leads.ROLE
FROM [CRMLite].[Leads]
