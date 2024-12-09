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
		,GroupCode
		,Price
		,Dimension
		,AppearInFront
		,Header
		,PrintExp
		,Description
		,Vat
		,Uid
		,CreationDate
		,LastModificationDate
	FROM dbo.[Products]
	WHERE AppearInFront = @AppearInFront;
END

