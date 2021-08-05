CREATE PROCEDURE [CRMLite].[GetAllWalletsByLeadID] @LeadID UNIQUEIDENTIFIER
AS
SELECT W.ID,
	C.ID,
	C.Name,
	W.Amount
FROM [CRMLite].[Wallets] W
LEFT JOIN [CRMLite].[Balance] B ON W.ID = B.WalletID
LEFT JOIN [CRMLite].[Currency] C ON W.Currency = C.ID
WHERE B.LeadID = @LeadID
