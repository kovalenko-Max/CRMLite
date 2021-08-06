CREATE PROCEDURE [CRMLite].[CreateTransaction]
	@ID UNIQUEIDENTIFIER,
	@OperationType tinyint,
	@WalletFrom UNIQUEIDENTIFIER,
	@WalletTo UNIQUEIDENTIFIER,
	@Amount decimal(18,0),
	@Timestamp datetime
AS
INSERT INTO [CRMLite].[Transactions] (
	ID,
	OperationType,
	WalletFrom,
	WalletTo,
	Amount,
	Timestamp
	)
VALUES (
	@ID,
	@OperationType,
	@WalletFrom,
	@WalletTo,
	@Amount,
	@Timestamp
	)