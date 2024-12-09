CREATE PROCEDURE [dbo].[spProducts_GetAll]
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
	FROM dbo.[Products];
END
