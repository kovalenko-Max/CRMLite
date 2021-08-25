CREATE TABLE [CRMLite].[Balance] (
    [LeadID]   UNIQUEIDENTIFIER NOT NULL,
    [WalletID] UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [Balance_fk0] FOREIGN KEY ([WalletID]) REFERENCES [CRMLite].[Wallets] ([ID])
);
GO

CREATE INDEX [IX_Balance_LeadID] ON [CRMLite].[Balance] ([LeadID])
GO
CREATE INDEX [IX_Balance_WalletID] ON [CRMLite].[Balance] ([WalletID])
