CREATE PROCEDURE [dbo].[spActivations_GetByMail]
	@Email nvarchar(50)
AS
BEGIN
	SELECT TOP 1
		 Id
		,Email
		,Code
		,ExpirationDate
		,CreationDate
		,LastModificationDate
	FROM dbo.[Activations]
	WHERE Email = @Email
	ORDER BY CreationDate DESC;
END
