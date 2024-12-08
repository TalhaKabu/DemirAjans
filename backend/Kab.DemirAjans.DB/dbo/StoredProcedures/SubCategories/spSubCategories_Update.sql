CREATE PROCEDURE [dbo].[spSubCategories_Update]
	@Id int,
	@Name nvarchar(50),
	@ImageName uniqueidentifier,
	@CategoryId int,
	@Skid int,
	@LastModificationDate datetime2(7)
AS
BEGIN
	UPDATE dbo.[SubCategories]
	SET Name = @Name, ImageName = @ImageName, @CategoryId = @CategoryId, Skid = @Skid, LastModificationDate = @LastModificationDate
	WHERE Id = @Id
END
