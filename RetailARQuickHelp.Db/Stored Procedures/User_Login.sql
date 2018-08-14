CREATE PROCEDURE [auth].[User_Login]
				@UserName	   nvarchar(255)
			  , @Xml		   XML output
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @ID INT

	SELECT @ID = usr.[Id]
	  FROM [auth].[User] as usr
	WHERE usr.[UserName] = @UserName and usr.[Status] = 1
	
    UPDATE [auth].[User]
		SET LastLoginOn = GETDATE()
	WHERE Id = @ID

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
						WHERE usr.[Id]=@ID
						FOR XML RAW('User'), TYPE)
				FOR XML PATH('Users'),TYPE)

END