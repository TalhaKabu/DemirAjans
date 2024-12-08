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
		,Dimension
		,AppearInFront
		,Header
		,Color
		,Description
		,Vat
		,Uid
		,CreationDate
		,LastModificationDate
	FROM dbo.[Products]
	WHERE AppearInFront = @AppearInFront;
END

