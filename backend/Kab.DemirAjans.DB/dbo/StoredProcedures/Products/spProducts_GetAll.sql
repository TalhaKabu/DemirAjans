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
		,Dimension
		,AppearInFront
		,CreationDate
		,LastModificationDate
	FROM dbo.[Products];
END
