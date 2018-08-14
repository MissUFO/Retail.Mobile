CREATE PROCEDURE [dbo].[Process_List]
				@Xml		   XML output
AS
BEGIN
	SET NOCOUNT ON;
	
	SET @Xml = (SELECT (SELECT	   p.[Id]
								  ,p.[ImageUrl]
								  ,p.[Name]
								  ,p.[Description]
								  ,p.[CreatedOn]
								  ,p.[ModifiedOn]
								  ,(SELECT (SELECT  d.[Id]
												  ,pd.[ProcessId]
												  , d.[Title]
												  , d.[Description]
												  , d.[DocumentUrl]
												  , d.[DocumentType]
												  , d.[CreatedOn]
												  , d.[ModifiedOn]
											FROM [dbo].[Document] AS d
												LEFT JOIN [map].[ProcessDocument] pd ON pd.[DocumentId] = d.[Id]
											WHERE pd.[ProcessId] = p.[Id]
												ORDER BY d.[DocumentType] ASC
										FOR XML RAW('Document'), TYPE)
									FOR XML PATH('Documents'),TYPE)
						FROM [dbo].[Process] AS p
						ORDER BY p.[Name] asc
						FOR XML RAW('Process'), TYPE)
				FOR XML PATH('Processes'),TYPE)

END