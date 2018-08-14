CREATE PROCEDURE [conf].[AppSettings_GetByKey]
				@Key			   nvarchar(255)
			  , @Xml			   XML output
AS
BEGIN
	SET NOCOUNT ON;
	
	SET @Xml = (SELECT (SELECT	   setting.[Id]
								  ,setting.[Key]
								  ,setting.[Value]
								  ,setting.[CreatedOn]
								  ,setting.[ModifiedOn]
						FROM [conf].[AppSettings] AS setting
						WHERE setting.[Key] = @Key
						FOR XML RAW('AppSetting'), TYPE)
				FOR XML PATH('AppSettings'),TYPE)

END