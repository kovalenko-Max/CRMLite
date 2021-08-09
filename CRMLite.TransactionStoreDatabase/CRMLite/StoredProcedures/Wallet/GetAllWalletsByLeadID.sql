CREATE PROCEDURE [CRMLite].[GetAllWalletsByLeadID] @LeadID UNIQUEIDENTIFIER
AS
SELECT W.ID,
	C.ID as CurrencyID,
	W.Amount	
FROM [CRMLite].[Wallets] W
LEFT JOIN [CRMLite].[Balance] B ON w.ID = B.WalletID
LEFT JOIN [CRMLite].[Currencies] C ON W.CurrencyID = C.ID
WHERE B.LeadID = @LeadID
