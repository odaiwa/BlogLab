CREATE PROCEDURE [dbo].[Blog_Update]
	@Blog BlogType READONLY,
	@ApplicationUserId INT

AS
	MERGE INTO Blog TARGET
	USING(
		SELECT 
			BlogId,
			@ApplicationUserId [ApplicationUserId],
			Titel,
			Content,
			PhotoId
		FROM
			@Blog
		)AS SOURCE
		ON
		(
			TARGET.BlogId = SOURCE.BlogId AND TARGET.ApplicationUserId = SOURCE.ApplicationUserId
		)
		WHEN MATCHED THEN 
			UPDATE SET
				TARGET.[Titel]=SOURCE.[Titel],
				TARGET.[Content]=SOURCE.[Content],
				TARGET.[PhotoId]=SOURCE.[PhotoId],
				TARGET.[UpdateDate]=GETDATE()
		WHEN NOT MATCHED BY TARGET THEN
			INSERT(
				[ApplicationUserId],
				[Titel],
				[Content],
				[PhotoId]
			)
			VALUES(
				SOURCE.[ApplicationUserId],
				SOURCE.[Titel],
				SOURCE.[Content],
				SOURCE.[PhotoId]
			);
		SELECT CAST(SCOPE_IDENTITY() AS INT);