CREATE PROCEDURE [dbo].[spCategories_GetAll]
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
	FROM dbo.[Categories];
END