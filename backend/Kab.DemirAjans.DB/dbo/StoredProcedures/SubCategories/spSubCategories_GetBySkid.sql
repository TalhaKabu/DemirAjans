CREATE PROCEDURE [dbo].[spSubCategories_GetBySkid]
	@Skid int
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
	WHERE @Skid = @Skid;
END