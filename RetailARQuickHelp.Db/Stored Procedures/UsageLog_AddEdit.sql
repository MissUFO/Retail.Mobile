CREATE PROCEDURE [logs].[UsageLog_AddEdit]
		   @Id int = null
		  ,@UserId int = null
		  ,@ActionType int = 0
		  ,@PageUrl nvarchar(255)
		  ,@OccurredOn datetime = null
AS
BEGIN
	SET NOCOUNT ON;

		-- Create a new record
		INSERT INTO [logs].[UsageLog]
           ([UserId]
           ,[ActionType]
           ,[PageUrl]
           ,[OccurredOn])
     VALUES
           (@UserId
           ,@ActionType
           ,@PageUrl
           ,ISNULL(@OccurredOn, GETDATE()))

END