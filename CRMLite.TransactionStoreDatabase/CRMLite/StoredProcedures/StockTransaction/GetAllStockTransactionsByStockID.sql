CREATE PROCEDURE [CRMLite].[GetAllStockTransactionsByStockID] @StockID UNIQUEIDENTIFIER
AS
SELECT *
FROM [CRMLite].[StockTransactions]
WHERE StockID = @StockID
