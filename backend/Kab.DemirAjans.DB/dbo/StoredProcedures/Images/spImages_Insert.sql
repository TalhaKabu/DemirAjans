CREATE PROCEDURE [dbo].[spImages_Insert]
	@Id uniqueidentifier,
	@ProductId int,
	@IsFrontImage int,
	@CreationDate datetime2(7),
	@LastModificationDate datetime2(7)
AS
BEGIN
	INSERT INTO dbo.[Images] (Id, ProductId, IsFrontImage, CreationDate, LastModificationDate)
	VALUES (@Id, @ProductId, @IsFrontImage, @CreationDate, @LastModificationDate);
END
