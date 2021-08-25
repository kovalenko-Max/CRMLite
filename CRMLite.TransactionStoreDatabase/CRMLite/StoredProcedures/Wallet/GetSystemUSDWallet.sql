CREATE PROCEDURE [CRMLite].[GetSystemUSDWallet]
	AS
	SELECT 
	W.ID,
	W.CurrencyID,
	W.Amount,
	C.ID,
	C.Title,
	C.Code
	from [CRMLite].[Wallets] W
	join [Currencies] C on C.ID = W.CurrencyID
	where W.ID = '8488F45B-DD2F-41C2-87D4-D9161EA26CDB'