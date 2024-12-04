CREATE PROCEDURE [dbo].[spProducts_Insert]
	@Name nvarchar(50),
	@CategoryId int,
	@SubCategoryId int,
	@Code nvarchar(20),
	@Price decimal(18,2),
	@Dimension nvarchar(30),
	@CreationDate datetime2(7),
	@LastModificationDate datetime2(7)
AS
BEGIN
	INSERT INTO dbo.[Products] 
		(Name, CategoryId, SubCategoryId, Code, Price, Dimension, CreationDate, LastModificationDate)
	VALUES 
		(@Name, @CategoryId, @SubCategoryId, @Code, @Price, @Dimension, @CreationDate, @LastModificationDate);
	SELECT IDENT_CURRENT ('dbo.[Products]');
END
