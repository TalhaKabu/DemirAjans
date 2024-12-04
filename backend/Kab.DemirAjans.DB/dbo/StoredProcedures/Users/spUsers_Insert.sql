CREATE PROCEDURE [dbo].[spUsers_Insert]
	@Username nvarchar(50),
	@Password nvarchar(50),
	@Name nvarchar(50),
	@LastName nvarchar(50),
	@Email nvarchar(50),
	@IsAdmin bit
AS
BEGIN
	INSERT INTO dbo.[Users] (Username, Password, Name, LastName, Email, IsAdmin)
	VALUES (@Username, @Password, @Name, @LastName, @Email, @IsAdmin);
END
