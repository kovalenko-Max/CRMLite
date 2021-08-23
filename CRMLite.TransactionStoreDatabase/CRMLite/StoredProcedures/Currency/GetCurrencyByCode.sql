CREATE PROCEDURE [CRMLite].[GetCurrencyByCode] @Code nvarchar(50)
AS
SELECT *
FROM [CRMLite].[Currencies]
WHERE Code=@Code
