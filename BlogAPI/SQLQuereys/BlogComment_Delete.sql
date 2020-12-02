CREATE PROCEDURE [dbo].[BlogComment_Delete]
	@BlogCommentId INT

AS
	DROP TABLE IF EXISTS #BlogCommentToBeDeleted;

WITH cte_blogComments AS (
	SELECT
		t1.[BlogCommentId],
		t1.[ParentBlogCommentId]
	FROM
		[dbo].[BlogComment] t1
	WHERE
		t1.[BlogCommentId] = @BlogCommentId
	UNION ALL
	SELECT
		t2.[BlogCommentId],
		t2.[ParentBlogCommentId]
	FROM
		[dbo].[BlogComment] t2
		INNER JOIN cte_blogComments t3
			ON t3.[BlogCommentId] = t2.[ParentBlogCommentId]
)

SELECT 
	[BlogCommentId],
	[ParentBlogCommentId]
INTO
	#BlogCommentsToBeDeleted
FROM
	cte_blogComments;

	UPDATE t1
	SET 
		t1.[ActiveInd] = CONVERT(BIT,1),
		t1.[UpdateDate] = GETDATE()
	FROM
		[dbo].[BlogComment] t1
		INNER JOIN #BlogCommentsToBeDeleted t2
			ON t1.[BlogCommentId] =t2.[BlogCommentId];

GO