CREATE TYPE [CRMLite].[ExchangeRateTimeTable] AS TABLE
(
	[Id] UNIQUEIDENTIFIER NULL,
	[Timestamp] DATETIME NULL,
	[Code] nvarchar (6) NULL,
	[Value] decimal(18,6) NULL
);