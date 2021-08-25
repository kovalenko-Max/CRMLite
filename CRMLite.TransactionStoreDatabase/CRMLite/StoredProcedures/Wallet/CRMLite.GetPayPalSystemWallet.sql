CREATE PROCEDURE [CRMLite].[GetPayPalSystemWallet]
AS
	SELECT 
	ID, 
	CurrencyID,
	Amount
	from [CRMLite].[Wallets] W
	join [CRMLite].[Balance] B on W.ID = B.WalletID

	where B.LeadID = '471A2146-82BC-4C18-9425-2D8CC89F8540'