CREATE PROCEDURE [CRMLite].[GetStockPortfolioByLead] @LeadID UNIQUEIDENTIFIER
AS
SELECT SP.LeadID,
	SP.ID AS StockPortfolioID,
	S.ID AS StockID,
	S.Title,
	S.IsDividend,
	SP.Quantity
FROM [CRMLite].[StockPortfolio] SP
LEFT JOIN [CRMLite].[Stock] S ON SP.StockID = S.ID
WHERE SP.LeadID = @LeadID
