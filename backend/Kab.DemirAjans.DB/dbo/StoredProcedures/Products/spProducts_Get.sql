CREATE PROCEDURE [dbo].[spProducts_Get]
	@Id int
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
	FROM dbo.[Products]
	WHERE Id = @Id;
END