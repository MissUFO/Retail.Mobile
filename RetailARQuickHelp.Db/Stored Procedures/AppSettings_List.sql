CREATE PROCEDURE [conf].[AppSettings_List]
				@Xml		   XML output
AS
BEGIN
	SET NOCOUNT ON;
	
	SET @Xml = (SELECT (SELECT	   setting.[Id]
								  ,setting.[Key]
								  ,setting.[Value]
								  ,setting.[CreatedOn]
								  ,setting.[ModifiedOn]
						FROM [conf].[AppSettings] AS setting
						ORDER BY setting.[Key] asc
						FOR XML RAW('AppSettings'), TYPE)
				FOR XML PATH('Settings'),TYPE)

END