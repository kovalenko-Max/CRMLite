CREATE PROCEDURE [CRMLite].[CreateCurrencyId]@ID int,
@Title NVARCHAR(255)
AS
	insert into [CRMLite].Currencies(
	ID,
	Title)
	Values (
	@ID,
	@Title)