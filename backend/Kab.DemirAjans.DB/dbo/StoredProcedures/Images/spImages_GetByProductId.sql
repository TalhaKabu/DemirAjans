CREATE PROCEDURE [dbo].[spImages_GetByProductId]
	@ProductId int
AS
BEGIN
	SELECT
		 Id
		,IsFrontImage
		,ProductId
		,CreationDate
		,LastModificationDate
	FROM dbo.[Images]
	WHERE ProductId = @ProductId;
END
