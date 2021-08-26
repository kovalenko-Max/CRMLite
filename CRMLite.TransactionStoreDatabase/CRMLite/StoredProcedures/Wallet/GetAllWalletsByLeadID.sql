CREATE PROCEDURE [CRMLite].[GetAllWalletsByLeadID] @LeadID UNIQUEIDENTIFIER
AS
SELECT W.ID,
    W.Amount,
	C.ID,
	C.Code,
	C.Title
FROM [CRMLite].[Wallets] W
LEFT JOIN [CRMLite].[Balance] B ON W.ID = B.WalletID
LEFT JOIN [CRMLite].[Currencies] C ON W.CurrencyID = C.ID
WHERE B.LeadID = @LeadID
