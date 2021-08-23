--DECLARE @i INT
--DECLARE @FirstName NVARCHAR(255)
--DECLARE @LastName NVARCHAR(255)
--DECLARE @PassportNumber NVARCHAR(8)
--DECLARE @TIN NVARCHAR(12)
--DECLARE @Email NVARCHAR(255)
--DECLARE @Password NVARCHAR(255)
--DECLARE @Status NVARCHAR(255)
--DECLARE @guid UNIQUEIDENTIFIER
--DECLARE @RoleId INT

--INSERT [CRMLite].[Roles] (Title)
--VALUES (User),
--	(Admin)

--SET @i = 1;

--WHILE @i <= 100000
--BEGIN
--	SET @guid = newid()
--	SET @FirstName = 'FirstName' + '-' + cast(@i AS NVARCHAR)
--	SET @LastName = 'LastName' + '-' + cast(@i AS NVARCHAR)
--	SET @PassportNumber = N'ВК-5' + cast(@i AS NVARCHAR)
--	SET @Password = '$2a$11$EOxdZNckFs/Wyv7Fq/rfkOpUlLh1dhz98.qw8.a5KSlLER9usFHSa'
--	SET @TIN = '3044' + cast(@i AS NVARCHAR)
--	SET @Email = 'email' + cast(@i AS NVARCHAR) + '@gmail.com'

--	IF (@i % 10 = 0)
--		SET @Status = 'Blocked';
--	ELSE IF (@i % 2 = 0)
--		SET @Status = 'Regular';
--	ELSE
--		SET @Status = 'VIP';

--	INSERT INTO [CRMLite].[Leads] (
--		ID,
--		FirstName,
--		LastName,
--		PassportNumber,
--		TIN,
--		Email,
--		Password,
--		STATUS
--		)
--	VALUES (
--		@guid,
--		@FirstName,
--		@LastName,
--		@PassportNumber,
--		@TIN,
--		@Email,
--		@Password,
--		@Status
--		)

--	IF (@i % 2 = 0)
--		SET @RoleID = 1
--	ELSE
--		SET @RoleID = 2

--	SET @i = @i + 1

--	INSERT INTO [CRMLite].[Lead_Role] (
--		LeadID,
--		RoleID
--		)
--	VALUES (
--		@guid,
--		@RoleID
--		)
--END;
