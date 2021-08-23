CREATE PROCEDURE [CRMLite].[CreateCurrencyRates] @ExchangeRates
AS
[CRMLite].[ExchangeRateTimeTable] readonly AS

INSERT INTO [CRMLite].[CurrencyRates] (
	Id,
	TIMESTAMP,
	Code,
	Value
	)
SELECT Id,
	TIMESTAMP,
	Code,
	Value
FROM @ExchangeRates
