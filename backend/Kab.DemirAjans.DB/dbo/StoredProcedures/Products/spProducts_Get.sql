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
	WHERE Id = @Id;
END