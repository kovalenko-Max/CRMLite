CREATE PROCEDURE [CRMLite].[CreateStockTransaction]
	@ID UNIQUEIDENTIFIER,
	@IsDeposit bit,
	@StockPortfolioID UNIQUEIDENTIFIER,
	@StockID UNIQUEIDENTIFIER,
	@Quontity int,
	@StockPrice decimal(18,0),
	@Timestamp datetime
AS
INSERT INTO [CRMLite].[StockTransactions] (
	ID,
	IsDeposit,
	StockPortfolioID,
	StockID,
	Quontity,
	StockPrice,
	Timestamp
	)
VALUES (
	@ID,
	@IsDeposit,
	@StockPortfolioID,
	@StockID,
	@Quontity,
	@StockPrice,
	@Timestamp
	)
