CREATE PROCEDURE [dbo].[spSubCategories_GetByCategoryId]
	@CategoryId int
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
	WHERE CategoryId = @CategoryId;
END


