CREATE TABLE [CRMLite].[StockTransactions]
(
	ID uniqueidentifier NOT NULL,
	IsDeposit BIT NOT NULL,
	StockPortfolioID uniqueidentifier NOT NULL,
	[Quantity] int NOT NULL,
	StockPrice decimal(18, 6) NOT NULL,
	[Timestamp] datetime NOT NULL,
	CONSTRAINT [StockTransactions_fk0] FOREIGN KEY ([StockPortfolioID]) REFERENCES [CRMLite].[StockPortfolio]([ID]),
)