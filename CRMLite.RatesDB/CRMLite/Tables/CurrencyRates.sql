CREATE TABLE [CRMLite].[CurrencyRates]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
	[Timestamp] DATETIME NOT NULL,
	[Code] nvarchar (6) NOT NULL,
	[Value] decimal(18,6) NOT NULL
)
GO

CREATE INDEX [IX_ExchangeRates_Code] ON [CRMLite].[CurrencyRates] ([Code])