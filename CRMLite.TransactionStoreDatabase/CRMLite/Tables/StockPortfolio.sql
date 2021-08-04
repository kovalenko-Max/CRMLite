CREATE TABLE [CRMLite].[StockPortfolio]
(
	ID uniqueidentifier NOT NULL,
	LeadID uniqueidentifier NOT NULL,
	StockID uniqueidentifier NOT NULL,
	Quontity int NOT NULL,
	CONSTRAINT [StockPortfolio_fk0] FOREIGN KEY ([StockID]) REFERENCES [CRMLite].[Stock]([ID])
)