CREATE PROCEDURE [CRMLite].[GetPayPalSystemWallet]
AS
	SELECT 
	W.ID, 
	W.CurrencyID,
	W.Amount,
	C.ID,
	C.Title,
	C.Code
	from [CRMLite].[Wallets] W
	join [CRMLite].[Currencies] C on C.ID = W.CurrencyID
	where W.ID = 'E04B8052-BF0C-41A2-A0FE-5CC331E95E17'