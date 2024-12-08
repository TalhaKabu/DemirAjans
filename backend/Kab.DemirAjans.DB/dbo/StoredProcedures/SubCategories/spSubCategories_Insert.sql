CREATE PROCEDURE [dbo].[spSubCategories_Insert]
	@Name nvarchar(50),
	@ImageName uniqueidentifier,
	@CategoryId int,
	@Skid int,
	@CreationDate datetime2(7),
	@LastModificationDate datetime2(7)
AS
BEGIN
	INSERT INTO dbo.[SubCategories] (Name, ImageName, CategoryId, Skid, CreationDate, LastModificationDate)
	VALUES (@Name, @ImageName, @CategoryId, @Skid, @CreationDate, @LastModificationDate);
END

