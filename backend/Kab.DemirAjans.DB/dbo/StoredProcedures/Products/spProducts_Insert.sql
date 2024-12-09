CREATE PROCEDURE [dbo].[spProducts_Insert]
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
	@CreationDate datetime2(7),
	@LastModificationDate datetime2(7)
AS
BEGIN
	INSERT INTO dbo.[Products] 
		(Name, CategoryId, SubCategoryId, Code, Price, Vat, AppearInFront, ImageName, Dimension, PrintExp, Description, CreationDate, LastModificationDate)
	VALUES 
		(@Name, @CategoryId, @SubCategoryId, @Code, @Price, @Vat, @AppearInFront, @ImageName, @Dimension, @PrintExp, @Description, @CreationDate, @LastModificationDate);
	SELECT IDENT_CURRENT ('dbo.[Products]');
END
