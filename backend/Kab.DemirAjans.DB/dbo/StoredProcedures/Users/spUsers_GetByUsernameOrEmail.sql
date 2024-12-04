CREATE PROCEDURE [dbo].[spUsers_GetByUsername]
	@Username nvarchar(50),
	@Email nvarchar(50)
AS
BEGIN
	SELECT
		 Id
		,UserName
		,Password
		,Name
		,LastName
		,Email
		,IsAdmin
		,CreationDate
		,LastModificationDate
	FROM dbo.[Users]
	WHERE Username = @Username OR Email = @Email;
END
