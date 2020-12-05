CREATE PROCEDURE [dbo].[Photo_Delete]
		@PhotoId INT
AS
	DELETE FROM [dbo].[Photo] WHERE [PhotoId] = @PhotoId
