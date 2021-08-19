CREATE TABLE [CRMLite].[Transactions] (
    [ID]             UNIQUEIDENTIFIER NOT NULL,
    [LeadID]        UNIQUEIDENTIFIER NOT NULL,
    [Amount]         DECIMAL (18, 6)  NOT NULL,
    [Timestamp]      DATETIME    NOT NULL,
    [WalletFrom]    UNIQUEIDENTIFIER NOT NULL,
    [WalletTo]      UNIQUEIDENTIFIER NOT NULL,
    [OperationType] TINYINT NOT NULL, 
    CONSTRAINT [Trasactions_fk0] FOREIGN KEY ([OperationType]) REFERENCES [CRMLite].[OperationTypes] ([ID]),
    CONSTRAINT [Trasactions_fk1] FOREIGN KEY ([WalletFrom]) REFERENCES [CRMLite].[Wallets] ([ID]),
    CONSTRAINT [Trasactions_fk2] FOREIGN KEY ([WalletTo]) REFERENCES [CRMLite].[Wallets] ([ID]),
    UNIQUE NONCLUSTERED ([ID] ASC)
);