CREATE PROCEDURE [dbo].[spCategories_Update]
	@Id int,
	@Name nvarchar(20),
	@ImageName uniqueidentifier,
	@LastModificationDate datetime2(7),
	@AppearInFront bit
AS
BEGIN
	UPDATE dbo.[Categories]
	SET Name = @Name, ImageName = @ImageName, LastModificationDate = @LastModificationDate, AppearInFront = @AppearInFront
	WHERE Id = @Id
END
