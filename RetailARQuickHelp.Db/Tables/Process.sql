CREATE TABLE [dbo].[Process] (
    [Id]          INT             IDENTITY (1, 1) NOT NULL,
    [ImageUrl]    NVARCHAR (255)  NULL,
    [Name]        NVARCHAR (50)   NOT NULL,
    [Description] NVARCHAR (2048) NULL,
    [CreatedOn]   DATETIME       CONSTRAINT [DF_Process_CreatedOn] DEFAULT (getdate()) NULL,
    [ModifiedOn]  DATETIME       CONSTRAINT [DF_Process_ModifiedOn] DEFAULT (getdate()) NULL,
    CONSTRAINT [PK_Process] PRIMARY KEY CLUSTERED ([Id] ASC)
);



