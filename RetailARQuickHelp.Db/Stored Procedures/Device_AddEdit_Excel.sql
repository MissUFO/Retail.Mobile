CREATE PROCEDURE [dbo].[Device_AddEdit_Excel]
		   @QrCode nvarchar(50) 
		  ,@Name nvarchar(255)
		  ,@Model nvarchar(255) = null
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @DeviceId  INT = 0

	SELECT @DeviceId = DeviceId FROM [map].[DeviceQrCode] WHERE QRCode = @QrCode
	
	IF NOT EXISTS (SELECT 1 FROM dbo.Device WHERE Id = @DeviceId)
	BEGIN
		insert into dbo.Device(Name, Model) values(@Name, @Model)
		
		SET @DeviceId = SCOPE_IDENTITY();
	END
	
	IF NOT EXISTS (SELECT 1 FROM [map].[DeviceQrCode] WHERE QRCode = @QrCode)
	BEGIN
		 insert into [map].[DeviceQrCode](QRCode, DeviceId) values(@QrCode, @DeviceId)
	END

END