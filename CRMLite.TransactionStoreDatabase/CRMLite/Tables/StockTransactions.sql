CREATE TABLE [CRMLite].[StockTransactions]
(
	ID uniqueidentifier NOT NULL,
	IsDeposit BIT NOT NULL,
	StockPortfolioID uniqueidentifier NOT NULL,
	StockID uniqueidentifier NOT NULL,
	Quontity int NOT NULL,
	StockPrice decimal NOT NULL,
	Timestamp datetime NOT NULL,
	CONSTRAINT [StockTransactions_fk0] FOREIGN KEY ([StockPortfolioID]) REFERENCES [CRMLite].[StockPortfolio]([ID]),
	CONSTRAINT [StockTransactions_fk1] FOREIGN KEY ([StockID]) REFERENCES [CRMLite].[Stock]([ID])
)