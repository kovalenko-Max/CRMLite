CREATE PROCEDURE [CRMLite].[CreateCurrency] @Title NVARCHAR(50)
AS
INSERT INTO [CRMLite].[Currencies] (Title)
VALUES (@Title)

