CREATE PROCEDURE [dbo].[spProducts_GetByCode]
	@Code nvarchar(20)
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
	WHERE Code = @Code;
END