CREATE PROCEDURE [CRMLite].[GetLastStockRate]
@code NVARCHAR(8)
AS
	SELECT TOP 1
	[Id],
	[Timestamp],
	[Code],
	[Value]
	FROM [CRMLite].[StockRates]
	WHERE Code = @code
	ORDER BY [Id] DESC