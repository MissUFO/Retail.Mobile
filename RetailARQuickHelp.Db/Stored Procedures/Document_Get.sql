CREATE PROCEDURE [dbo].[Document_Get]
				 @Id			INT
			    ,@Xml			XML output
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
						WHERE document.Id = @Id
							ORDER BY document.[DocumentType] ASC
					FOR XML RAW('Document'), TYPE)
				FOR XML PATH('Document'),TYPE)
END