CREATE PROCEDURE [CRMLite].[CreateTransaction] @ID UNIQUEIDENTIFIER,
	@OperationType TINYINT,
	@WalletFrom UNIQUEIDENTIFIER,
	@WalletTo UNIQUEIDENTIFIER,
	@Amount DECIMAL(18, 6),
	@Timestamp DATETIME
AS
INSERT INTO [CRMLite].[Transactions] (
	ID,
	OperationType,
	WalletFrom,
	WalletTo,
	Amount,
	TIMESTAMP
	)
VALUES (
	@ID,
	@OperationType,
	@WalletFrom,
	@WalletTo,
	@Amount,
	@Timestamp
	)

UPDATE CRMLite.Wallets
SET Amount = Amount - @Amount
WHERE ID = @WalletFrom

UPDATE CRMLite.Wallets
SET Amount = Amount + @Amount
WHERE ID = @WalletTo
