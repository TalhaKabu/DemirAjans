CREATE PROCEDURE [dbo].[spSubCategories_Insert]
	@Name nvarchar(50),
	@ImageName uniqueidentifier,
	@CategoryId int,
	@CreationDate datetime2(7),
	@LastModificationDate datetime2(7)
AS
BEGIN
	INSERT INTO dbo.[SubCategories] (Name, ImageName, CategoryId, CreationDate, LastModificationDate)
	VALUES (@Name, @ImageName, @CategoryId, @CreationDate, @LastModificationDate);
END

