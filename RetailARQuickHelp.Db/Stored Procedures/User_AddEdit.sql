CREATE PROCEDURE [auth].[User_AddEdit]
		   @UserName nvarchar(255) 
		  ,@FirstName nvarchar(255) = null
		  ,@LastName nvarchar(255) = null
		  ,@MiddleName nvarchar(255) = null
		  ,@EmployeeId bigint = 0
		  ,@PhoneNumber nvarchar(50) = null
		  ,@Email nvarchar(255) = null
		  ,@StoreId int = 1
		  ,@Status bit = 1
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @ID INT = 0

	SELECT @ID = usr.[Id]
	  FROM [auth].[User] as usr
	WHERE usr.[EmployeeId] = @EmployeeId
	
	IF (@ID IS NOT NULL AND @ID <> 0)
	BEGIN
	-- Update record
	UPDATE [auth].[User]
	   SET [UserName] = @UserName
		  ,[FirstName] = ISNULL(@FirstName, FirstName)
		  ,[LastName] = ISNULL(@LastName, LastName)
		  ,[MiddleName] = ISNULL(@MiddleName, MiddleName)
		  ,[EmployeeId] = @EmployeeId
		  ,[PhoneNumber] = ISNULL(@PhoneNumber, PhoneNumber)
		  ,[Email] = ISNULL(@Email, Email)
		  ,[StoreId] = @StoreId
		  ,[Status] = @Status
		  ,[LastLoginOn] = GETDATE()
	 WHERE Id=@ID

	END
	ELSE
	BEGIN
	-- Create a new record
	INSERT INTO [auth].[User]
           ([UserName]
           ,[FirstName]
           ,[LastName]
           ,[MiddleName]
           ,[EmployeeId]
           ,[PhoneNumber]
           ,[Email]
           ,[StoreId]
           ,[Status]
           ,[CreatedOn]
           ,[ModifiedOn]
           ,[LastLoginOn])
     VALUES
           (@UserName
           ,@FirstName
           ,@LastName
           ,@MiddleName
           ,@EmployeeId
           ,@PhoneNumber
           ,@Email
           ,@StoreId
           ,@Status
           , GETDATE()
           , GETDATE()
           , GETDATE())
	END

END