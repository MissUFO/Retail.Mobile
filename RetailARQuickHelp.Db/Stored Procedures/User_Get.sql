CREATE PROCEDURE [auth].[User_Get]
				@Id			   INT
			  , @Xml		   XML output
AS
BEGIN
	SET NOCOUNT ON;
	
	SET @Xml = (SELECT (SELECT	   usr.[Id]
								  ,usr.[UserName]
								  ,usr.[FirstName]
								  ,usr.[LastName]
								  ,usr.[MiddleName]
								  ,usr.[EmployeeId]
								  ,usr.[PhoneNumber]
								  ,usr.[Email]
								  ,usr.[StoreId]
								  ,usr.[Status]
								  ,usr.[CreatedOn]
								  ,usr.[ModifiedOn]
								  ,usr.[LastLoginOn]
								  ,(SELECT	 
									   store.[Id]
									  ,store.[StoreId]
									  ,store.[Name]
									  ,store.[Email]
									  ,store.[Address]
									  ,store.[CreatedOn]
									  ,store.[ModifiedOn]
									FROM [auth].[Store] AS store
									WHERE store.[Id] = usr.[StoreId]
									FOR XML RAW('Store'), TYPE) 
						FROM [auth].[User] AS usr
						WHERE usr.[Id]=@Id
						FOR XML RAW('User'), TYPE)
				FOR XML PATH('Users'),TYPE)

END