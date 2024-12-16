CREATE PROCEDURE [dbo].[spCarts_Insert]
	@UserId int,
	@ProductId int,
	@Quantity int,
	@CreationDate datetime2(7),
	@LastModificationDate datetime2(7)
AS
BEGIN
	INSERT INTO dbo.[Carts] (UserId, ProductId, Quantity, CreationDate, LastModificationDate)
	VALUES (@UserId, @ProductId, @Quantity, @CreationDate, @LastModificationDate);
END

