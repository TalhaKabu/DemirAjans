CREATE PROCEDURE [dbo].[spProducts_Update]
	@Id int,
	@Name nvarchar(50),
	@CategoryId int,
	@SubCategoryId int,
	@Code nvarchar(20),
	@Price decimal(18,2),
	@Vat int,
	@AppearInFront bit,
	@ImageName uniqueidentifier,
	@Dimension nvarchar(30),
	@PrintExp nvarchar(50),
	@Description nvarchar(750),
	@LastModificationDate datetime2(7)
AS
BEGIN
	UPDATE dbo.[products]
	SET Name = @Name, @CategoryId = @CategoryId, SubCategoryId = @SubCategoryId, Code = @Code, Price = @Price, Dimension = @Dimension, AppearInFront = @AppearInFront, ImageName = @ImageName, PrintExp = @PrintExp, Description = @Description, Vat = @Vat, LastModificationDate = @LastModificationDate
	WHERE Id = @Id
END
