CREATE PROCEDURE [dbo].[spCarts_GetByUserId]
	@UserId int
AS
BEGIN
	SELECT
		 Id
		,UserId
		,ColorId
		,Quantity
		,CreationDate
		,LastModificationDate
	FROM dbo.[Carts]
	WHERE UserId = @UserId;
END
