CREATE PROCEDURE [dbo].[spProducts_GetAllByCategoryAndSubCategoryId]
	@CategoryId int,
	@SubCategoryId int NULL
AS
BEGIN
	SELECT
		 Id
		,Name
		,CategoryId
		,SubCategoryId
		,Code
		,Price
		,Vat
		,AppearInFront
		,ImageName
		,Dimension
		,PrintExp
		,Description
		,CreationDate
		,LastModificationDate
	FROM dbo.[Products]
	WHERE CategoryId = @CategoryId AND (@SubCategoryId IS NULL OR SubCategoryId = @SubCategoryId);
END


