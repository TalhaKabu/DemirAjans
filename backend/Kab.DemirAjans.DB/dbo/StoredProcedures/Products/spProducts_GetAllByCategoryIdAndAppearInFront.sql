CREATE PROCEDURE [dbo].[spProducts_GetAllByCategoryIdAndAppearInFront]
	@CategoryId int,
	@AppearInFront bit
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
	WHERE CategoryId = @CategoryId AND AppearInFront = @AppearInFront;
END


