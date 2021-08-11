CREATE PROCEDURE [CRMLite].[GetAllTransactionsByWalletID] @WalletID UNIQUEIDENTIFIER
AS
SELECT T.ID,
	T.OperationType,
	T.WalletFrom,
	T.WalletTo,
	T.Amount,
	T.TIMESTAMP
FROM [CRMLite].[Transactions] T
LEFT JOIN [CRMLite].[Wallets] WF ON T.WalletFrom = WF.ID
LEFT JOIN [CRMLite].[Wallets] WT ON T.WalletTo = WT.ID
LEFT JOIN [CRMLite].[Balance] BF ON BF.WalletID = WF.ID
LEFT JOIN [CRMLite].[Balance] BT ON BT.WalletID = WT.ID
WHERE BT.WalletID = @WalletID
	OR BF.WalletID = @WalletID