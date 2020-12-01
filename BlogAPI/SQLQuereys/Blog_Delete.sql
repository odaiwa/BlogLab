CREATE PROCEDURE [dbo].[Blog_Delete]
	@BlogId INT
AS
	UPDATE [dbo].[BlogComment]
	SET [ActiveInd] = CONVERT(BIT,0)
	WHERE [BlogId] = @BlogId;

	UPDATE [dbo].[Blog]
	SET
		[PhotoId] = NULL,
		[ActiveInd] = CONVERT (BIT,0)
	WHERE
		[BlogId] = @BlogId