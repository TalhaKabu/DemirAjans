CREATE PROCEDURE [dbo].[spActivations_Insert]
	@Code nvarchar(6),
	@Email nvarchar(50),
	@ExpirationDate datetime2(7),
	@CreationDate datetime2(7),
	@LastModificationDate datetime2(7)
AS
BEGIN
	INSERT INTO dbo.[Activations] (Code, Email, ExpirationDate, CreationDate, LastModificationDate)
	VALUES (@Code, @Email, @ExpirationDate, @CreationDate, @LastModificationDate);
END
