CREATE PROCEDURE [dbo].[spCategories_Insert]
	@Name nvarchar(50),
	@ImageName uniqueidentifier,
	@Kid int,
	@CreationDate datetime2(7),
	@LastModificationDate datetime2(7),
	@AppearInFront bit
AS
BEGIN
	INSERT INTO dbo.[Categories] (Name, ImageName, Kid, CreationDate, LastModificationDate, AppearInFront)
	VALUES (@Name, @ImageName, @Kid, @CreationDate, @LastModificationDate, @AppearInFront);
END
