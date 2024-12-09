CREATE PROCEDURE [dbo].[spProducts_GetAll]
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
	FROM dbo.[Products];
END
