﻿CREATE TABLE [CRMLite].[Balance] (
    [LeadID]   UNIQUEIDENTIFIER NOT NULL,
    [WalletID] UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [Balance_fk0] FOREIGN KEY ([WalletID]) REFERENCES [CRMLite].[Wallet] ([ID])
);

