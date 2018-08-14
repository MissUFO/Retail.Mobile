CREATE TABLE [logs].[UsageLog] (
    [Id]           INT             IDENTITY (1, 1) NOT NULL,
    [UserId]       INT             NULL,
    [ActionType]   INT			   CONSTRAINT [DF_UsageLog_ActionType] DEFAULT ((0)) NOT NULL,
    [PageUrl]	   NVARCHAR (255)  NOT NULL,
    [OccurredOn]   DATETIME        CONSTRAINT [DF_UsageLog_OccurredOn] DEFAULT (getdate()) NOT NULL
    CONSTRAINT [PK_UsageLog] PRIMARY KEY CLUSTERED ([Id] ASC)
);

