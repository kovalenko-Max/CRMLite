CREATE PROCEDURE [CRMLite].[CreateStockTransaction] @ID UNIQUEIDENTIFIER,
	@IsDeposit BIT,
	@StockPortfolioID UNIQUEIDENTIFIER,
	@StockID UNIQUEIDENTIFIER,
	@Quontity INT,
	@StockPrice DECIMAL(18, 0),
	@Timestamp DATETIME
AS
INSERT INTO [CRMLite].[StockTransactions] (
	ID,
	IsDeposit,
	StockPortfolioID,
	StockID,
	Quontity,
	StockPrice,
	[Timestamp]
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
