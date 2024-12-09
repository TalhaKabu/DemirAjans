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
	WHERE Id = @Id;
END