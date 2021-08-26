CREATE PROCEDURE [CRMLite].[CreateCurrencyRates]
	@ExchangeRates as [CRMLite].[ExchangeRateTimeTable] readonly
AS
	INSERT INTO [CRMLite].[CurrencyRates] (Id, Timestamp, Code, Value)
	SELECT Id, Timestamp, Code, Value FROM @ExchangeRates