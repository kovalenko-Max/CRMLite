CREATE TABLE [CRMLite].[Wallets] (
    [ID]       UNIQUEIDENTIFIER NOT NULL,
    [Currency] TINYINT       NOT NULL,
    [Amount]   DECIMAL (18)  NOT NULL,
    CONSTRAINT [PK_WALLET] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [Wallet_fk0] FOREIGN KEY ([Currency]) REFERENCES [CRMLite].[Currency] ([ID])
);