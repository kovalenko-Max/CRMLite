CREATE TABLE [CRMLite].[StockPortfolio]
(
 ID uniqueidentifier NOT NULL,
 LeadID uniqueidentifier NOT NULL,
 [StockID] uniqueidentifier NOT NULL,
 [Quantity] int NOT NULL,
 CONSTRAINT [PK_STOCK_PORTFOLIO] PRIMARY KEY CLUSTERED ([ID] ASC),
 CONSTRAINT [StockPortfolio_fk0] FOREIGN KEY ([StockID]) REFERENCES [CRMLite].[Stock]([ID])
)
GO

CREATE INDEX [IX_StockPortfolio_LeadID] ON [CRMLite].[StockPortfolio] ([LeadID])