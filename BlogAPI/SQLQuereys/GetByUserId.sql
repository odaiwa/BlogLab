CREATE PROCEDURE [dbo].[Blog_GetByUserId]
	@ApplicationUserId INT
AS
SELECT [BlogId]
	  ,[ApplicationUserId]
	  ,[Username]
	  ,[Titel]
	  ,[Content]
	  ,[PhotoId]
	  ,[PublishDate]
	  ,[UpdateDate]
FROM 
	   [aggregate].[Blog] t1
WHERE
	   t1.ApplicationUserId = @ApplicationUserId AND 
	   t1.ActiveInd = CONVERT(BIT,1)

