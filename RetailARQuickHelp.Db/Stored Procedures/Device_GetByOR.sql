CREATE PROCEDURE [dbo].[Device_GetByOR]
				@QRCode			   nvarchar(50)
			  , @Xml			   XML output
AS
BEGIN
	SET NOCOUNT ON;
	
	SET @Xml = (SELECT (SELECT	   d.[Id]
								  --,qr.[QRCode]
								  ,d.[Name]
								  ,d.[ImageUrl]
								  ,d.[Model]
								  ,d.[Description]
								  ,d.[CreatedOn]
								  ,d.[ModifiedOn]
								  ,(SELECT dt.[Id]
										  ,dt.[Name]
										FROM [enum].[DeviceType] AS dt
										WHERE dt.[Id] = d.[DeviceType]
									FOR XML RAW('DeviceType'), TYPE)
								  ,(SELECT (SELECT q.[Id]
												  ,q.[QRCode] as Code
												  ,q.[DeviceId]
											FROM [map].[DeviceQrCode] AS q
											WHERE q.[DeviceId] = d.[Id]
										FOR XML RAW('Barcode'), TYPE)
									FOR XML PATH('Barcodes'),TYPE)
								  ,(SELECT (SELECT img.[Id]
												  ,d.[Id] as DeviceId
												  ,img.[Title]
												  ,img.[Description]
												  ,img.[Url]
												  ,img.[Order]
												  ,img.[CreatedOn]
												  ,img.[ModifiedOn]
											FROM [dbo].[Image] AS img
												LEFT JOIN map.DeviceImage device ON device.[ImageId] = img.[Id]
											WHERE device.[DeviceId] = d.[Id]
												ORDER BY img.[Order] ASC
										FOR XML RAW('Image'), TYPE)
									FOR XML PATH('Images'),TYPE)
								  ,(SELECT (SELECT  document.[Id]
												  ,d.[Id] as DeviceId
												  ,document.[Title]
												  ,document.[Description]
												  ,document.[DocumentUrl]
												  ,document.[DocumentType]
												  ,document.[CreatedOn]
												  ,document.[ModifiedOn]
											FROM [dbo].[Document] AS document
												LEFT JOIN map.DeviceDocument device ON device.DocumentId = document.Id
											WHERE device.DeviceId = d.Id
												ORDER BY document.DocumentType ASC
										FOR XML RAW('Document'), TYPE)
									FOR XML PATH('Documents'),TYPE)
								   ,(SELECT (SELECT issue.[Id]
													,d.[Id] as DeviceId
													,issue.[Title]
													,issue.[Description]
													,issue.[Resolution]
													,issue.[CreatedOn]
													,issue.[ModifiedOn]
											FROM [dbo].[Issue] AS issue
												LEFT JOIN map.DeviceIssue device ON device.IssueId = issue.Id
											WHERE device.DeviceId = d.Id
												ORDER BY issue.[Title] ASC
										FOR XML RAW('Issue'), TYPE)
									FOR XML PATH('Issues'),TYPE)
						FROM [map].[DeviceQrCode] AS qr
							LEFT JOIN [dbo].Device d ON d.Id=qr.DeviceId
						WHERE CHARINDEX(qr.[QRCode], @QRCode)>0 OR CHARINDEX('00'+qr.[QRCode], @QRCode)>0 OR CHARINDEX('0'+qr.[QRCode], @QRCode)>0
						FOR XML RAW('Device'), TYPE)
				FOR XML PATH('Devices'),TYPE)

END