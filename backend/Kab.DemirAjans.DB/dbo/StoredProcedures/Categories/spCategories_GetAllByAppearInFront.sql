CREATE PROCEDURE [dbo].[spCategories_GetAllByAppearInFront]
	@AppearInFront bit
AS
BEGIN
	SELECT
		 Id
		,Name
		,ImageName
		,CreationDate
		,LastModificationDate
		,AppearInFront
	FROM dbo.[Categories]
	WHERE AppearInFront = @AppearInFront;
END