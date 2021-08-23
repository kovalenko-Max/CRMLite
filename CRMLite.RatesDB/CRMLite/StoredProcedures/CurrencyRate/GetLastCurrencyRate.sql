CREATE PROCEDURE [CRMLite].[GetLastCurrencyRate] @code NVARCHAR(8)
AS
SELECT TOP 1 [Id],
	[Timestamp],
	[Code],
	[Value]
FROM [CRMLite].[CurrencyRates]
WHERE Code = @code
ORDER BY [Id] DESC
