CREATE PROCEDURE [CRMLite].[GetAllStockTransactionsByStockPortfolioID] @StockPortfolioID UNIQUEIDENTIFIER
AS
SELECT *
FROM [CRMLite].[StockTransactions]
WHERE StockPortfolioID = @StockPortfolioID
