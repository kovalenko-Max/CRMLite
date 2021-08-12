CREATE PROCEDURE [CRMLite].[GetAllStockTransactionsByLeadID] @LeadID UNIQUEIDENTIFIER
AS
SELECT *
FROM [CRMLite].[StockTransactions] ST
LEFT JOIN [CRMLite].[StockPortfolio] SP ON ST.StockPortfolioID = SP.ID
WHERE SP.LeadID = @LeadID
