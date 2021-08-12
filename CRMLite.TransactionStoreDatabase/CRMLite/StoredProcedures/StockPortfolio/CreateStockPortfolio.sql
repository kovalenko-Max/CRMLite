CREATE PROCEDURE [CRMLite].[CreateStockPortfolio]
	@ID UNIQUEIDENTIFIER,
	@LeadID UNIQUEIDENTIFIER,
	@StockID UNIQUEIDENTIFIER,
	@Quantity int
AS
INSERT INTO [CRMLite].[StockPortfolio] (
	ID,
	LeadID,
	StockID,
	Quantity
	)
VALUES (
	@ID,
	@LeadID,
	@StockID,
	@Quantity
	)