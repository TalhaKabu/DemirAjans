CREATE PROCEDURE [dbo].[spUsers_Get]
	@Id int
AS
BEGIN
	SELECT
		 Id
		,UserName
		,Password
		,Name
		,LastName
		,Email
		,IsAdmin
		,CreationDate
		,LastModificationDate
	FROM dbo.[Users]
	WHERE Id = @Id;
END

