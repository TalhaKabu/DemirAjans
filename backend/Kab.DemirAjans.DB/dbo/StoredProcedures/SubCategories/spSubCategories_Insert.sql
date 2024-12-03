CREATE PROCEDURE [dbo].[spSubCategories_Insert]
	@Name nvarchar(50),
	@CategoryId int,
	@Code nvarchar(3),
	@CreationDate datetime2(7),
	@LastModificationDate datetime2(7)
AS
BEGIN
	INSERT INTO dbo.[SubCategories] (Name, CategoryId, Code, CreationDate, LastModificationDate)
	VALUES (@Name, @CategoryId, @Code, @CreationDate, @LastModificationDate);
END

