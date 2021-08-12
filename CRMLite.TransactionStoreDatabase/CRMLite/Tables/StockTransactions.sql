CREATE TABLE [CRMLite].[StockTransactions]
(
	ID uniqueidentifier NOT NULL,
	IsDeposit BIT NOT NULL,
	StockPortfolioID uniqueidentifier NOT NULL,
	Quontity int NOT NULL,
	StockPrice decimal NOT NULL,
	Timestamp datetime NOT NULL,
	CONSTRAINT [StockTransactions_fk0] FOREIGN KEY ([StockPortfolioID]) REFERENCES [CRMLite].[StockPortfolio]([ID]),
)