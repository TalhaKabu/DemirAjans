CREATE PROCEDURE [dbo].[spSubCategories_Insert]
	@Name nvarchar(20),
	@CategoryId int,
	@CreationDate datetime2(7),
	@LastModificationDate datetime2(7)
AS
BEGIN
	INSERT INTO dbo.[SubCategories] (Name, CategoryId, CreationDate, LastModificationDate)
	VALUES (@Name, @CategoryId, @CreationDate, @LastModificationDate);
END

