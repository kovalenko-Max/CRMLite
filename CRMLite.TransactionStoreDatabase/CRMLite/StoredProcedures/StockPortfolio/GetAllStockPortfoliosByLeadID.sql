CREATE PROCEDURE [CRMLite].[GetAllStockPortfoliosByLeadID] @LeadID UNIQUEIDENTIFIER
AS
SELECT SP.ID,
	SP.LeadID,
	SP.Quantity,
	S.ID,
	S.Title,
	S.IsDividend
FROM [CRMLite].[StockPortfolio] SP
LEFT JOIN [CRMLite].[Stock] S ON SP.StockID = S.ID
WHERE SP.LeadID = @LeadID
