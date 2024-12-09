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
		,Vat
		,AppearInFront
		,ImageName
		,Dimension
		,PrintExp
		,Description
		,CreationDate
		,LastModificationDate
	FROM dbo.[Products]
	WHERE Id = @Id;
END