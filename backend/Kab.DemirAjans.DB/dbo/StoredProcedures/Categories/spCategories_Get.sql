CREATE PROCEDURE [dbo].[spCategories_Get]
	@Id int
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
	FROM dbo.[Categories]
	WHERE Id = @Id;
END
