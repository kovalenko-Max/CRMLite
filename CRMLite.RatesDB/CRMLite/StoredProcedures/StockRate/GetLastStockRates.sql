CREATE PROCEDURE [CRMLite].[GetLastStockRates] @Codes
	AS
[CRMLite].[CodesTimeTable] readonly AS

DECLARE @Code NVARCHAR(8)
DECLARE @result [CRMLite].[ExchangeRateTimeTable]

DECLARE my_cur CURSOR
FOR
SELECT Code
FROM @Codes

OPEN my_cur

FETCH NEXT
FROM my_cur
INTO @Code

WHILE @@FETCH_STATUS = 0
BEGIN
	INSERT INTO @result
	SELECT TOP 1 Id,
		[TIMESTAMP],
		Code,
		[Value]
	FROM [CRMLite].[StockRates]
	WHERE Code = @Code
	ORDER BY TIMESTAMP DESC

	FETCH NEXT
	FROM my_cur
	INTO @Code
END

CLOSE my_cur

DEALLOCATE my_cur

SELECT Id,
	[TIMESTAMP],
	Code,
	[Value]
FROM @result
