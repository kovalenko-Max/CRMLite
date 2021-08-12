CREATE PROCEDURE [CRMLite].[CreateOperationType] @Type NVARCHAR(50)
AS
INSERT INTO [CRMLite].[OperationTypes] (
	[Type]
	)
VALUES (
	@Type
	)