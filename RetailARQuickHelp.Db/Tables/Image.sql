CREATE TABLE [dbo].[Image] (
    [Id]          INT             IDENTITY (1, 1) NOT NULL,
    [Url]         NVARCHAR (255)  NOT NULL,
    [Title]       NVARCHAR (255)  NOT NULL,
    [Description] NVARCHAR (1024) NULL,
    [Order]       INT             CONSTRAINT [DF_Image_Order] DEFAULT ((0)) NULL,
    [CreatedOn]   DATETIME        CONSTRAINT [DF_Image_CreatedOn] DEFAULT (getdate()) NULL,
    [ModifiedOn]  DATETIME        CONSTRAINT [DF_Image_ModifiedOn] DEFAULT (getdate()) NULL,
    CONSTRAINT [PK_Image] PRIMARY KEY CLUSTERED ([Id] ASC)
);

