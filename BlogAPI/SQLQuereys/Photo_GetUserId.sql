CREATE PROCEDURE [dbo].[Photo_GetUserId]
		@ApplicationUserId INT
AS

SELECT t1.[PhotoId]
      ,t1.[ApplicationUserId]
      ,t1.[PublicId]
      ,t1.[ImageUrl]
      ,t1.[Description]
      ,t1.[PublishDate]
      ,t1.[UpdateDate]
  FROM [dbo].[Photo] t1

  WHERE
	t1.[ApplicationUserId]=@ApplicationUserId

