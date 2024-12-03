CREATE PROCEDURE [dbo].[spSubCategories_Update]
	@Id int,
	@Name nvarchar(50),
	@CategoryId int,
	@Code nvarchar(3),
	@LastModificationDate datetime2(7)
AS
BEGIN
	UPDATE dbo.[SubCategories]
	SET Name = @Name, @CategoryId = @CategoryId, Code = @Code, LastModificationDate = @LastModificationDate
	WHERE Id = @Id
END
