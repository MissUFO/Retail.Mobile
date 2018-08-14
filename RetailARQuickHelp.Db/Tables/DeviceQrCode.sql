CREATE TABLE [map].[DeviceQrCode] (
    [Id]       INT           IDENTITY (1, 1) NOT NULL,
    [QRCode]   NVARCHAR (50) NOT NULL,
    [DeviceId] INT           NOT NULL,
    CONSTRAINT [PK_DeviceQRCode] PRIMARY KEY CLUSTERED ([Id] ASC)
);

