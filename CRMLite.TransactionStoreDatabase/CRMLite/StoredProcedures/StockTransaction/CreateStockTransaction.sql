CREATE PROCEDURE [CRMLite].[CreateStockTransaction] @ID UNIQUEIDENTIFIER,
	@IsDeposit BIT,
	@StockPortfolioID UNIQUEIDENTIFIER,
	@Quontity INT,
	@StockPrice DECIMAL(18, 0),
	@Timestamp DATETIME
AS
INSERT INTO [CRMLite].[StockTransactions] (
	ID,
	IsDeposit,
	StockPortfolioID,
	Quontity,
	StockPrice,
	[Timestamp]
	)
VALUES (
	@ID,
	@IsDeposit,
	@StockPortfolioID,
	@Quontity,
	@StockPrice,
	@Timestamp
	)
