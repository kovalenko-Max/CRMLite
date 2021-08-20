CREATE PROCEDURE [CRMLite].[CreateStock] @ID UNIQUEIDENTIFIER,
	@Title NVARCHAR(255),
	@IsDividend BIT
AS
INSERT INTO [CRMLite].[Stock] (
	ID,
	Title,
	IsDividend
	)
VALUES (
	@ID,
	@Title,
	@IsDividend
	)