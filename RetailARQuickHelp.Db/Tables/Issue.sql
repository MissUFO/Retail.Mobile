CREATE TABLE [dbo].[Issue] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Title]       NVARCHAR (255) NOT NULL,
    [Description] NVARCHAR (MAX) NULL,
    [Resolution]  NVARCHAR (MAX) NULL,
    [CreatedOn]   DATETIME       CONSTRAINT [DF_Issue_CreatedOn] DEFAULT (getdate()) NULL,
    [ModifiedOn]  DATETIME       CONSTRAINT [DF_Issue_ModifiedOn] DEFAULT (getdate()) NULL,
    CONSTRAINT [PK_Issue] PRIMARY KEY CLUSTERED ([Id] ASC)
);

