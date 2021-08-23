CREATE TABLE [CRMLite].[Wallets] (
    [ID]       UNIQUEIDENTIFIER NOT NULL,
    [CurrencyID] INT       NOT NULL,
    [Amount]   DECIMAL (18, 6)  NOT NULL,
    CONSTRAINT [PK_WALLET] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [Wallet_fk0] FOREIGN KEY ([CurrencyID]) REFERENCES [CRMLite].[Currencies] ([ID])
);