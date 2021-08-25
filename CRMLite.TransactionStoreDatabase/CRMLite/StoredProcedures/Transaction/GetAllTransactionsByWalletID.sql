CREATE PROCEDURE [CRMLite].[GetAllTransactionsByWalletID] @WalletID UNIQUEIDENTIFIER
AS
SELECT T.ID,
	T.LeadID,
	T.Amount,
	T.[TIMESTAMP],
	WF.ID WalletFromID,
	WF.Amount WalletFromAmount,
	CF.ID CurrencyFromID, 
	CF.Code CurrencyFromCode,
	CF.Title CurrencyFromTitle,
	WT.ID WalletToID,
	WT.Amount WalletToAmount,
	CT.ID CurrencyToID,
	CT.Code CurrencyToCode,
	CT.Title CurrencyToTitle,
	OT.ID OperationTypeID,
	OT.[Type] OperationTypeType
FROM [CRMLite].[Transactions] T
LEFT JOIN [CRMLite].[Wallets] WF ON T.WalletFrom = WF.ID
LEFT JOIN [CRMLite].[Currencies] CF ON WF.CurrencyID = CF.ID
LEFT JOIN [CRMLite].[Wallets] WT ON T.WalletTo = WT.ID
LEFT JOIN [CRMLite].[Currencies] CT ON WT.CurrencyID = CT.ID
LEFT JOIN [CRMLite].[OperationTypes] OT ON T.OperationType = OT.ID
WHERE WF.ID = @WalletID
	OR WT.ID = @WalletID