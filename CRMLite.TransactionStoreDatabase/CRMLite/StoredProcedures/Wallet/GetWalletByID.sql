CREATE PROCEDURE [CRMLite].[GetWalletByID] @ID UNIQUEIDENTIFIER
AS
SELECT W.ID,
	W.Amount,
	C.ID,
	C.Code,
	C.Title
FROM [CRMLite].[Wallets] W
LEFT JOIN [CRMLite].[Currencies] C ON W.CurrencyID = C.ID
WHERE W.ID = @ID
