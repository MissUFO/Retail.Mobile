CREATE TABLE [map].[DeviceIssue] (
    [Id]       INT IDENTITY (1, 1) NOT NULL,
    [DeviceId] INT NOT NULL,
    [IssueId]  INT NOT NULL,
    CONSTRAINT [PK_DeviceIssue] PRIMARY KEY CLUSTERED ([Id] ASC)
);

