CREATE PROCEDURE [dbo].[Issue_List]
				 @deviceId			INT
			    ,@Xml			XML output
AS
BEGIN
	SET NOCOUNT ON;

	SET @Xml = (SELECT (SELECT issue.[Id]
							  ,device.[DeviceId]
							  ,issue.[Title]
							  ,issue.[Description]
							  ,issue.[Resolution]
							  ,issue.[CreatedOn]
							  ,issue.[ModifiedOn]
						FROM [dbo].[Issue] AS issue
							LEFT JOIN map.DeviceIssue device ON device.IssueId = issue.Id
						WHERE device.DeviceId = @deviceId
							ORDER BY issue.[Title] ASC
					FOR XML RAW('Issue'), TYPE)
				FOR XML PATH('Issues'),TYPE)
END