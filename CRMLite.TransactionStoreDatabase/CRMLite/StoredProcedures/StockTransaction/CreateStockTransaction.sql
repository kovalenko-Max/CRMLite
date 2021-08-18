﻿CREATE PROCEDURE [CRMLite].[CreateStockTransaction] @ID UNIQUEIDENTIFIER,
	@IsDeposit BIT,
	@StockPortfolioID UNIQUEIDENTIFIER,
	@Quantity INT,
	@StockPrice DECIMAL(18, 6),
	@Timestamp DATETIME
AS
INSERT INTO [CRMLite].[StockTransactions] (
	ID,
	IsDeposit,
	StockPortfolioID,
	Quantity,
	StockPrice,
	[Timestamp]
	)
VALUES (
	@ID,
	@IsDeposit,
	@StockPortfolioID,
	@Quantity,
	@StockPrice,
	@Timestamp
	)

IF @IsDeposit = (1)
	UPDATE [CRMLite].[StockPortfolio]
	SET Quantity = Quantity + @Quantity
	WHERE ID = @StockPortfolioID
ELSE
	UPDATE [CRMLite].[StockPortfolio]
	SET Quantity = Quantity - @Quantity
	WHERE ID = @StockPortfolioID
