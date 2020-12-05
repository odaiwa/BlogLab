CREATE PROCEDURE [dbo].[BlogComment_Upsert]
		@BlogComment BlogCommentType READONLY,
		@ApplicationUserId INT
	AS
	MERGE INTO [dbo].[BlogComment] TARGET
	USING(
		SELECT
		[BlogCommentId],
		[ParentBlogCommentId],
		[BlogId],
		[Content],
		@ApplicationUserId [ApplicationUserId]
		FROM
		@BlogComment
	
	)AS SOURCE
	ON(
			TARGET.[BlogCommentId]=SOURCE.[BlogCommentId] AND TARGET.[ApplicationUserId] = SOURCE.[ApplicationUserId]
	   )
	   WHEN MATCHED THEN
			UPDATE SET
			TARGET.[Content]=SOURCE.[Content],
			TARGET.[UpdateDate]=GETDATE()
		WHEN NOT MATCHED BY TARGET THEN
		INSERT(
			[ParentBlogCommentId],
			[BlogId],
			[ApplicationUserId],
			[Content]
		)
		VALUES(
		SOURCE.[ParentBlogCommentId],
		SOURCE.[BlogId],
		SOURCE.[ApplicationUserId],
		SOURCE.[Content]
		);

		SELECT CAST(SCOPE_IDENTITY() AS INT);

