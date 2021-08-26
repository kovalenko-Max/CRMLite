CREATE PROCEDURE [CRMLite].[ResetIdentityInAllTables]
AS
EXEC sp_MSforeachtable @command1 = 'DECLARE @tNameTemp varchar(100) = convert(varchar(100), (select SUBSTRING(''?'', 12,100)));
DECLARE @lenght int = convert(int,(SELECT LEN(@tNameTemp)))-1;
DECLARE @tName varchar(100) = convert(varchar(100),(SELECT LEFT(@tNameTemp, @lenght)));
Print @tName
DECLARE @last_value INT = CONVERT(INT, (
			SELECT last_value
			FROM sys.identity_columns
			WHERE OBJECT_NAME(object_id) = @tName
			));

IF @last_value IS NULL
	DBCC CHECKIDENT(''?'', RESEED, 1)
ELSE
	DBCC CHECKIDENT(''?'', RESEED, 0)',
	@whereand = ' AND EXISTS (SELECT 1 FROM sys.columns WHERE object_id = o.id  AND is_identity = 1)'
