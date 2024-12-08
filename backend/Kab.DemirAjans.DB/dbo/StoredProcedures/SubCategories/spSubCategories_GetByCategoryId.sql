CREATE PROCEDURE [dbo].[spSubCategories_GetByCategoryId]
	@CategoryId int
AS
BEGIN
	SELECT
		 Id
		,Name
		,ImageName
		,CategoryId
		,Skid
		,CreationDate
		,LastModificationDate
	FROM dbo.[SubCategories]
	WHERE CategoryId = @CategoryId;
END


