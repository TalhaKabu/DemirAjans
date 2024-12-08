CREATE PROCEDURE [dbo].[spSubCategories_GetAll]
AS
BEGIN
	SELECT 
		 Id
		,Name
		,ImageName
		,CategoryId
		,CreationDate
		,LastModificationDate
	FROM dbo.[SubCategories]
END
