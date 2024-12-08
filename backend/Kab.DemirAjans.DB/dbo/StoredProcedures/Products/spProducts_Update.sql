CREATE PROCEDURE [dbo].[spProducts_Update]
	@Id int,
	@Name nvarchar(50),
	@CategoryId int,
	@SubCategoryId int,
	@Code nvarchar(20),
	@Price decimal(18,2),
	@Dimension nvarchar(30),
	@AppearInFront bit,
	@Header nvarchar(100),
	@Color nvarchar(50),
	@Description nvarchar(300),
	@Vat int,
	@Uid int,
	@LastModificationDate datetime2(7)
AS
BEGIN
	UPDATE dbo.[products]
	SET Name = @Name, @CategoryId = @CategoryId, SubCategoryId = @SubCategoryId, Code = @Code, Price = @Price, Dimension = @Dimension, AppearInFront = @AppearInFront, Header = @Header, Color = @Color, Description = @Description, Vat = @Vat, Uid = @Uid, LastModificationDate = @LastModificationDate
	WHERE Id = @Id
END
