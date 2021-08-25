CREATE PROCEDURE [CRMLite].[CreateTransaction] 
	@ID UNIQUEIDENTIFIER,
	@LeadID UNIQUEIDENTIFIER,
	@Timestamp DATETIME,
	@WalletFrom UNIQUEIDENTIFIER,
	@WalletFromAmount DECIMAL(18, 6),
	@WalletTo UNIQUEIDENTIFIER,
	@WalletToAmount DECIMAL(18, 6),
	@OperationType TINYINT
AS
INSERT INTO [CRMLite].[Transactions] (
	ID,
	LeadID,
	Amount,
	[TIMESTAMP],
	WalletFrom,
	WalletTo,
	OperationType
	)
VALUES (
	@ID,
	@LeadID,
	@WalletFromAmount,
	@Timestamp,
	@WalletFrom,
	@WalletTo,
	@OperationType
	)

UPDATE CRMLite.Wallets
SET Amount = @WalletFromAmount
WHERE ID = @WalletFrom

UPDATE CRMLite.Wallets
SET Amount = @WalletToAmount
WHERE ID = @WalletTo