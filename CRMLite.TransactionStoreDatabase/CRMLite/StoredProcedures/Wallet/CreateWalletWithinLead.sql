CREATE PROCEDURE [CRMLite].[CreateWalletWithinLead] @LeadID UNIQUEIDENTIFIER,
	@ID UNIQUEIDENTIFIER,
	@CurrencyID TINYINT,
	@Amount DECIMAL(18, 6)
AS
INSERT INTO [CRMLite].[Wallets] (
	ID,
	CurrencyID,
	Amount
	)
VALUES (
	@ID,
	@CurrencyID,
	@Amount
	)

INSERT INTO [CRMLite].[Balance] (
	LeadID,
	WalletID
	)
VALUES (
	@LeadID,
	@ID
	)
