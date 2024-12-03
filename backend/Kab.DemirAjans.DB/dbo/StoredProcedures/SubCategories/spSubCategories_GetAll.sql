CREATE PROCEDURE [dbo].[spSubCategories_GetAll]
AS
BEGIN
	SELECT 
		 Id
		,Name
		,CategoryId
		,Code
		,CreationDate
		,LastModificationDate
	FROM dbo.[SubCategories]
END
