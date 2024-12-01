CREATE PROCEDURE [dbo].[spCategories_GetAll]
AS
BEGIN
	SELECT
		 Id
		,Name
		,ImageName
		,CreationDate
		,LastModificationDate
	FROM dbo.[Categories];
END