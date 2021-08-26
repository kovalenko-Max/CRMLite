CREATE TABLE [CRMLite].[Stock]
(
	ID uniqueidentifier NOT NULL,
	Title nvarchar(255) NOT NULL,
	Code nvarchar(255) NOT NULL UNIQUE,
	IsDividend BIT NOT NULL,
	CONSTRAINT [PK_STOCK] PRIMARY KEY CLUSTERED
	(
		[ID] ASC
	) WITH (IGNORE_DUP_KEY = OFF)
)
GO

CREATE INDEX [IX_Stock_Code] ON [CRMLite].[Stock] ([Code])