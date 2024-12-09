CREATE PROCEDURE [dbo].[spProducts_Insert]
	@Name nvarchar(50),
	@CategoryId int,
	@SubCategoryId int,
	@Code nvarchar(20),
	@GroupCode nvarchar(10),
	@Price decimal(18,2),
	@Dimension nvarchar(30),
	@AppearInFront bit,
	@Header nvarchar(100),
	@PrintExp nvarchar(50),
	@Description nvarchar(750),
	@Vat int,
	@Uid int,
	@CreationDate datetime2(7),
	@LastModificationDate datetime2(7)
AS
BEGIN
	INSERT INTO dbo.[Products] 
		(Name, CategoryId, SubCategoryId, Code, GroupCode, Price, Dimension, AppearInFront, Header, PrintExp, Description, Vat, Uid, CreationDate, LastModificationDate)
	VALUES 
		(@Name, @CategoryId, @SubCategoryId, @Code, @GroupCode, @Price, @Dimension, @AppearInFront, @Header, @PrintExp, @Description, @Vat, @Uid, @CreationDate, @LastModificationDate);
	SELECT IDENT_CURRENT ('dbo.[Products]');
END
