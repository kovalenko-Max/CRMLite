CREATE PROCEDURE [CRMLite].[CreateStock] @ID UNIQUEIDENTIFIER,
	@Title NVARCHAR(255),
	@Code NVARCHAR(255),
	@IsDividend BIT
AS
INSERT INTO [CRMLite].[Stock] (
	ID,
	Title,
	Code,
	IsDividend
	)
VALUES (
	@ID,
	@Title,
	@Code,
	@IsDividend
	)