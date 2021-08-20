CREATE PROCEDURE [CRMLite].[CreateCurrency]
@Code NVARCHAR(50),
@Title NVARCHAR(255)
AS
INSERT INTO [CRMLite].[Currencies] (Code, Title)
VALUES (@Code, @Title)

