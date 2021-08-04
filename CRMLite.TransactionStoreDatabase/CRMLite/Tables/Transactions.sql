CREATE TABLE [CRMLite].[Transactions] (
    [ID]             UNIQUEIDENTIFIER NOT NULL,
    [OperationType] TINYINT       NOT NULL,
    [WalletFrom]    UNIQUEIDENTIFIER NOT NULL,
    [WalletTo]      UNIQUEIDENTIFIER NOT NULL,
    [Amount]         DECIMAL (18)  NOT NULL,
    [Timestamp]      DATETIME    NOT NULL,
    CONSTRAINT [Trasactions_fk0] FOREIGN KEY ([OperationType]) REFERENCES [CRMLite].[OperationTypes] ([ID]),
    CONSTRAINT [Trasactions_fk1] FOREIGN KEY ([WalletFrom]) REFERENCES [CRMLite].[Wallet] ([ID]),
    CONSTRAINT [Trasactions_fk2] FOREIGN KEY ([WalletTo]) REFERENCES [CRMLite].[Wallet] ([ID]),
    UNIQUE NONCLUSTERED ([ID] ASC)
);