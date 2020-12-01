CREATE PROCEDURE [dbo].[Blog_Get]
		@BlogId INT
AS

SELECT [BlogId]
	  ,[ApplicationUserId]
	  ,[Username]
	  ,[Titel]
	  ,[Content]
	  ,[PhotoId]
	  ,[PublishDate]
	  ,[UpdateDate]
	  ,[ActiveInd]
FROM 
	   [aggregate].[Blog] t1
WHERE
	   t1.[BlogId]= @BlogId AND t1.ActiveInd = CONVERT(BIT,1)

