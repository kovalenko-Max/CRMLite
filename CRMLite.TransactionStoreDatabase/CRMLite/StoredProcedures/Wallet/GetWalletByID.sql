﻿CREATE PROCEDURE [CRMLite].[GetWalletByID] @ID UNIQUEIDENTIFIER
AS
SELECT [ID],
	[Currency],
	Amount
FROM [CRMLite].[Wallets]
WHERE ID = @ID
