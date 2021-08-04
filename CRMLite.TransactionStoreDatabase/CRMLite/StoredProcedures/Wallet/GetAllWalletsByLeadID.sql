﻿CREATE PROCEDURE [CRMLIte].[GetAllWalletsByLeadID] @LeadID UNIQUEIDENTIFIER
AS
SELECT W.ID
	,C.ID
	,C.Name
	,W.Amount
FROM [CRMLite].[Wallet] W
LEFT JOIN [CRMLite].[Balance] B ON w.ID = B.WalletID
LEFT JOIN [CRMLite].[Currency] C ON W.Currency = C.ID
WHERE B.LeadID = @LeadID
