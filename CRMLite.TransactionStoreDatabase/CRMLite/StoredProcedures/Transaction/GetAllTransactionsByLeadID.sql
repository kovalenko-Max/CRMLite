CREATE PROCEDURE [CRMLite].[GetAllTransactionsByLeadID] @LeadID UNIQUEIDENTIFIER
AS
SELECT T.ID,
	T.OperationType,
	T.WalletFrom,
	T.WalletTo,
	T.Amount,
	T.Timestamp
FROM [CRMLite].[Transactions] T
LEFT JOIN [CRMLite].[Wallets] WF on T.WalletFrom = WF.ID
LEFT JOIN [CRMLite].[Wallets] WT on T.WalletTo = WT.ID
LEFT JOIN [CRMLite].[Balance] BF on BF.WalletID = WF.ID
LEFT JOIN [CRMLite].[Balance] BT on BT.WalletID = WT.ID
Where BT.LeadID = @LeadID or BF.LeadID = @LeadID