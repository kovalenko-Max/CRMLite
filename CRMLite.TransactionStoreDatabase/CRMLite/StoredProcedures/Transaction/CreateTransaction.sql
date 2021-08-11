CREATE PROCEDURE [CRMLite].[CreateTransaction] @ID UNIQUEIDENTIFIER,
	@OperationType TINYINT,
	@WalletFrom UNIQUEIDENTIFIER,
	@WalletTo UNIQUEIDENTIFIER,
	@Amount DECIMAL(18, 0),
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