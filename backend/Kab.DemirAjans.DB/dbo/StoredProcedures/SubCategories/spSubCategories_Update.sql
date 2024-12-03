CREATE PROCEDURE [dbo].[spSubCategories_Update]
	@Id int,
	@Name nvarchar(50),
	@CategoryId int,
	@LastModificationDate datetime2(7)
AS
BEGIN
	UPDATE dbo.[SubCategories]
	SET Name = @Name, @CategoryId = @CategoryId, LastModificationDate = @LastModificationDate
	WHERE Id = @Id
END
