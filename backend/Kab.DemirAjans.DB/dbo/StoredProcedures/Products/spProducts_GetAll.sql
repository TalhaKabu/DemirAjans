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
		,CreationDate
		,LastModificationDate
	FROM dbo.[Products];
END
