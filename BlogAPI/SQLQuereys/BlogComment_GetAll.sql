CREATE PROCEDURE [dbo].[BlogComment_GetAll]
		@BlogId INT
	AS


SELECT t1.[BlogCommentId]
      ,t1.[ParentBlogCommentId]
      ,t1.[BlogId]
      ,t1.[ApplicationUserId]
	  ,t1.[Username]
      ,t1.[Content]
      ,t1.[PublishDate]
      ,t1.[UpdateDate]
  FROM [aggregate].[BlogComment] t1

  WHERE
	t1.[BlogId]=@BlogId AND
	t1.ActiveInd=CONVERT(BIT,1)
	ORDER BY t1.[UpdateDate]
	DESC

