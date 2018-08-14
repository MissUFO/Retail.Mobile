CREATE PROCEDURE [dbo].[Document_List]
				 @deviceId			INT
			    ,@Xml				XML output
AS
BEGIN
	SET NOCOUNT ON;

	SET @Xml = (SELECT (SELECT document.[Id]
							  ,device.[DeviceId]
							  ,document.[Title]
							  ,document.[Description]
							  ,document.[DocumentUrl]
							  ,document.[DocumentType]
							  ,document.[CreatedOn]
							  ,document.[ModifiedOn]
						FROM [dbo].[Document] AS document
							LEFT JOIN map.DeviceDocument device ON device.DocumentId = document.Id
						WHERE device.DeviceId = @deviceId
							ORDER BY document.DocumentType ASC
					FOR XML RAW('Document'), TYPE)
				FOR XML PATH('Documents'),TYPE)
END