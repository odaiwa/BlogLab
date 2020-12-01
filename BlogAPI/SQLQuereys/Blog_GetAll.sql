CREATE PROCEDURE [dbo].[Blog_GetAll]
	@Offset INT,
	@PageSize INT
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
	t1.[ActiveInd]=CONVERT(BIT,1)
ORDER BY
	t1.[BlogId]
OFFSET @Offset ROWS
FETCH NEXT @PageSize ROWS ONLY;

SELECT COUNT(*) FROM [aggregate].[Blog] t1 WHERE t1.[ActiveInd]=CONVERT(BIT,1);