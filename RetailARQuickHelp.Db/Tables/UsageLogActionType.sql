CREATE TABLE [enum].[UsageLogActionType] (
    [Id]   INT           NOT NULL,
    [Name] NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_UsageLogActionType] PRIMARY KEY CLUSTERED ([Id] ASC)
);

/*
0 - read
1 - write
2 - search
3 - scan
*/

