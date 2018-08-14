CREATE TABLE [map].[DeviceDocument] (
    [Id]         INT IDENTITY (1, 1) NOT NULL,
    [DeviceId]   INT NOT NULL,
    [DocumentId] INT NOT NULL,
    CONSTRAINT [PK_DeviceDocument] PRIMARY KEY CLUSTERED ([Id] ASC)
);

