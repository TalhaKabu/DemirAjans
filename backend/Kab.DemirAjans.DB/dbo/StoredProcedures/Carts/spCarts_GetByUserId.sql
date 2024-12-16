CREATE PROCEDURE [dbo].[spCarts_GetByUserId]
	@UserId int
AS
BEGIN
	SELECT
		 Id
		,UserId
		,ProductId
		,Quantity
		,CreationDate
		,LastModificationDate
	FROM dbo.[Carts]
	WHERE UserId = @UserId;
END
