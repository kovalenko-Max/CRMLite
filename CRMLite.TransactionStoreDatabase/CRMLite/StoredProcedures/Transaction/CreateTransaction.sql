CREATE PROCEDURE [CRMLite].[CreateTransaction] @ID UNIQUEIDENTIFIER,
	@LeadID UNIQUEIDENTIFIER,
	@Amount DECIMAL(18, 6),
	@Timestamp DATETIME,
	@WalletFrom UNIQUEIDENTIFIER,
	@WalletTo UNIQUEIDENTIFIER,
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
	@Amount,
	@Timestamp,
	@WalletFrom,
	@WalletTo,
	@OperationType
	)

UPDATE CRMLite.Wallets
SET Amount = Amount - @Amount
WHERE ID = @WalletFrom

UPDATE CRMLite.Wallets
SET Amount = Amount + @Amount
WHERE ID = @WalletTo
