CREATE PROCEDURE [dbo].[spColors_GetByProductId]
	@ProductId int
AS
BEGIN
	SELECT
		 Id
		,Name
		,ProductId
		,Code
		,Uid
		,ImageName
		,CreationDate
		,LastModificationDate
	FROM dbo.[Colors]
	WHERE ProductId = @ProductId;
END
