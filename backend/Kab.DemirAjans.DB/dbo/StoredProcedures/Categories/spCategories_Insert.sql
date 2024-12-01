CREATE PROCEDURE [dbo].[spCategories_Insert]
	@Name nvarchar(20),
	@ImageName uniqueidentifier,
	@CreationDate datetime2(7),
	@LastModificationDate datetime2(7)
AS
BEGIN
	INSERT INTO dbo.[Categories] (Name, ImageName, CreationDate, LastModificationDate)
	VALUES (@Name, @ImageName, @CreationDate, @LastModificationDate);
	SELECT IDENT_CURRENT('dbo.[Categories]')
END
