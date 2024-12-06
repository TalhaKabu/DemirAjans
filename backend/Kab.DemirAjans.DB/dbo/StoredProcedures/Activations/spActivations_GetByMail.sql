CREATE PROCEDURE [dbo].[spActivations_GetByMail]
	@Email nvarchar(50)
AS
BEGIN
	SELECT
		 Id
		,Email
		,Code
		,ExpirationDate
		,CreationDate
		,LastModificationDate
	FROM dbo.[Activations]
	WHERE Email = @Email;
END
