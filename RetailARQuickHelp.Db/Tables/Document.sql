CREATE TABLE [dbo].[Document] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [Title]        NVARCHAR (255) NOT NULL,
    [Description]  NVARCHAR (MAX) NULL,
    [DocumentUrl]  NVARCHAR (255) NOT NULL,
    [DocumentType] INT            CONSTRAINT [DF_Document_DocumentType_1] DEFAULT ((0)) NOT NULL,
    [CreatedOn]    DATETIME       CONSTRAINT [DF_Document_DocumentType] DEFAULT (getdate()) NULL,
    [ModifiedOn]   DATETIME       CONSTRAINT [DF_Document_ModifiedOn] DEFAULT (getdate()) NULL,
    CONSTRAINT [PK_Document] PRIMARY KEY CLUSTERED ([Id] ASC)
);

