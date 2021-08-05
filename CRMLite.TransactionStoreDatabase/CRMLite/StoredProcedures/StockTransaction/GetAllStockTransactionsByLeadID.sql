CREATE PROCEDURE [CRMLite].[GetAllStockTransactionsByLeadID] @LeadID UNIQUEIDENTIFIER
AS
SELECT * FROM [CRMLite].[StockTransactions] ST
LEFT JOIN [CRMLite].[StockPortfolio] SP on ST.StockPortfolioID = SP.ID
LEFT JOIN [CRMLite].[Stock] S on ST.StockID = S.ID
WHERE SP.LeadID = @LeadID
