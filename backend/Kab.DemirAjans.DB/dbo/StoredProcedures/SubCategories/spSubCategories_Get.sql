CREATE PROCEDURE [dbo].[spSubCategories_Get]
	@Id int
AS
BEGIN
	SELECT
		 Id
		,Name
		,CategoryId
		,CreationDate
		,LastModificationDate
	FROM dbo.[SubCategories]
	WHERE Id = @Id;
END
