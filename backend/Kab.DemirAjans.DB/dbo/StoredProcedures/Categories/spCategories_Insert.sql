CREATE PROCEDURE [dbo].[spCategories_Insert]
	@Name nvarchar(20),
	@ImageName uniqueidentifier,
	@CreationDate datetime2(7),
	@LastModificationDate datetime2(7),
	@AppearInFront bit
AS
BEGIN
	INSERT INTO dbo.[Categories] (Name, ImageName, CreationDate, LastModificationDate, AppearInFront)
	VALUES (@Name, @ImageName, @CreationDate, @LastModificationDate, @AppearInFront);
END
