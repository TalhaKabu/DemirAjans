CREATE PROCEDURE [dbo].[spSubCategories_Get]
	@Id int
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
	WHERE Id = @Id;
END
