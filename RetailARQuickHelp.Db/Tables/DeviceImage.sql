CREATE TABLE [map].[DeviceImage] (
    [Id]       INT IDENTITY (1, 1) NOT NULL,
    [DeviceId] INT NOT NULL,
    [ImageId]  INT NOT NULL,
    CONSTRAINT [PK_DeviceImage] PRIMARY KEY CLUSTERED ([Id] ASC)
);

