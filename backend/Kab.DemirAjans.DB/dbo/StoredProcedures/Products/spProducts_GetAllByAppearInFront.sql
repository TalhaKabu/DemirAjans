CREATE PROCEDURE [dbo].[spProducts_GetAllByAppearInFront]
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
	WHERE AppearInFront = @AppearInFront;
END

