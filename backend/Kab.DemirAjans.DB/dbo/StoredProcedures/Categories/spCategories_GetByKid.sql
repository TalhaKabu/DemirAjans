CREATE PROCEDURE [dbo].[spCategories_GetByKid]
	@Kid int
AS
BEGIN
	SELECT
		 Id
		,Name
		,ImageName
		,CreationDate
		,LastModificationDate
		,AppearInFront
		,Kid
	FROM dbo.[Categories]
	WHERE Kid = @Kid;
END
