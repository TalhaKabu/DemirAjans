CREATE PROCEDURE [dbo].[spSubCategories_Update]
	@Id int,
	@Name nvarchar(50),
	@ImageName uniqueidentifier,
	@CategoryId int,
	@LastModificationDate datetime2(7)
AS
BEGIN
	UPDATE dbo.[SubCategories]
	SET Name = @Name, ImageName = @ImageName, @CategoryId = @CategoryId, LastModificationDate = @LastModificationDate
	WHERE Id = @Id
END
