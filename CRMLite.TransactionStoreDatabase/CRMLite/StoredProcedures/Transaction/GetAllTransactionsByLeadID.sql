CREATE PROCEDURE [CRMLite].[GetAllTransactionsByLeadID] @LeadID UNIQUEIDENTIFIER
AS
SELECT 
	T.ID,
	T.LeadID,
	T.Amount,
	T.TIMESTAMP,
	T.OperationType,

	WF.ID WalletFromID,
	WF.Amount WalletFromAmount,

	CF.ID CurrencyFromID, 
	CF.Code CurrencyFromCode,
	CF.Title CurrencyFromTitle,

	WT.ID WalletToID,
	WT.Amount WalletToAmount,

	CT.ID CurrencyToID,
	CT.Code CurrencyToCode,
	CT.Title CurrencyToTitle
	
FROM [CRMLite].[Transactions] T
join [CRMLite].[Wallets] WF on WF.ID = T.WalletFrom
join [CRMLite].[Currencies] CF on WF.CurrencyID = CF.ID
join [CRMLite].[Wallets] WT on WT.ID = T.WalletTo
join [CRMLite].[Currencies] CT on WT.CurrencyID = CT.ID
where T.LeadID = @LeadID