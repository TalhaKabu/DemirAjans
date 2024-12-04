CREATE PROCEDURE [dbo].[spUsers_Insert]
	@Username nvarchar(50),
	@Password nvarchar(50),
	@Name nvarchar(50),
	@LastName nvarchar(50),
	@Email nvarchar(50),
	@IsAdmin bit,
	@CreationDate datetime2(7),
	@LastModificationDate datetime2(7)
AS
BEGIN
	INSERT INTO dbo.[Users] (Username, Password, Name, LastName, Email, IsAdmin, CreationDate, LastModificationDate)
	VALUES (@Username, @Password, @Name, @LastName, @Email, @IsAdmin, @CreationDate, @LastModificationDate);
END
