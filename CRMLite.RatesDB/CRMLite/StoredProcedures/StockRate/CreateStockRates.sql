CREATE PROCEDURE [CRMLite].[CreateStockRates]
	@ExchangeRates as [CRMLite].[ExchangeRateTimeTable] readonly
AS
	INSERT INTO [CRMLite].[StockRates] (Id, Timestamp, Code, Value)
	SELECT Id, Timestamp, Code, Value FROM @ExchangeRates