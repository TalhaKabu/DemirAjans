CREATE PROCEDURE [dbo].[spColors_Insert]
	@Name nvarchar(50),
	@Code nvarchar(20),
	@Header nvarchar(100),
	@ProductId int,
	@Uid int,
	@ImageName uniqueidentifier,
	@CreationDate datetime2(7),
	@LastModificationDate datetime2(7)
AS
BEGIN
	INSERT INTO dbo.[Colors] 
		(Name, Code, ProductId, Header, Uid, ImageName, CreationDate, LastModificationDate)
	VALUES 
		(@Name, @Code, @ProductId, @Header, @Uid, @ImageName, @CreationDate, @LastModificationDate);
	SELECT IDENT_CURRENT ('dbo.[Colors]');
END
