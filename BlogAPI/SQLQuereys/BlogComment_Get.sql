CREATE PROCEDURE [dbo].[BlogComment_Get]
	@BlogCommentId INT
AS

SELECT [BlogCommentId]
      ,[ParentBlogCommentId]
      ,[BlogId]
      ,[ApplicationUserId]
      ,[Content]
      ,[PublishDate]
      ,[UpdateDate]
      ,[ActiveInd]

  FROM [dbo].[BlogComment]
GO

