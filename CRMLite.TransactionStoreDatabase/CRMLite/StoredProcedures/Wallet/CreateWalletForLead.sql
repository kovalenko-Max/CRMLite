CREATE PROCEDURE [CRMLite].[CreateWalletForLead]
	@LeadID UNIQUEIDENTIFIER,
	@ID UNIQUEIDENTIFIER,
	@CurrencyID TINYINT
AS
	INSERT INTO [CRMLite].[Wallets] (
		ID,
		CurrencyID,
		Amount
	)
	VALUES (
		@ID,
		@CurrencyID,
		0
	)

	INSERT INTO [CRMLite].[Balance] (
		LeadID,
		WalletID
	)
	VALUES (
		@LeadID,
		@ID
	)