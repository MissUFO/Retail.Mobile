CREATE TABLE [map].[ProcessDocument] (
    [Id]          INT IDENTITY (1, 1) NOT NULL,
    [ProcessId]   INT NOT NULL,
    [DocumentId]  INT NOT NULL,
    CONSTRAINT [PK_ProcessDocument] PRIMARY KEY CLUSTERED ([Id] ASC)
);

