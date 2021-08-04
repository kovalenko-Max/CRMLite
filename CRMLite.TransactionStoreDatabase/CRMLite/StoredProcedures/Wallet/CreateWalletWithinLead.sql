CREATE PROCEDURE [CRMLite].[CreateWalletWithinLead] @LeadID UNIQUEIDENTIFIER
	,@WalletID UNIQUEIDENTIFIER
	,@Currency TINYINT
	,@Amount DECIMAL(18, 0)
AS
INSERT INTO [CRMLite].[Wallets] (
	ID
	,Currency
	,Amount
	)
VALUES (
	@WalletID
	,@Currency
	,@Amount
	)

INSERT INTO [CRMLite].[Balance] (
	LeadID
	,WalletID
	)
VALUES (
	@LeadID
	,@WalletID
	)
