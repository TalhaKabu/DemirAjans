CREATE PROCEDURE [dbo].[spCarts_Insert]
	@UserId int,
	@ColorId int,
	@Quantity int,
	@CreationDate datetime2(7),
	@LastModificationDate datetime2(7)
AS
BEGIN
	INSERT INTO dbo.[Carts] (UserId, ColorId, Quantity, CreationDate, LastModificationDate)
	VALUES (@UserId, @ColorId, @Quantity, @CreationDate, @LastModificationDate);
END

