CREATE TABLE [auth].[Store] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [StoreId]    INT            NOT NULL,
    [Name]       NVARCHAR (255) NOT NULL,
	[Email]      NVARCHAR (255) NULL,
    [Address]    NVARCHAR (255) NULL,
    [CreatedOn]  DATETIME       CONSTRAINT [DF_Store_CreatedOn] DEFAULT (getdate()) NOT NULL,
    [ModifiedOn] DATETIME       CONSTRAINT [DF_Store_ModifiedOn] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_Store] PRIMARY KEY CLUSTERED ([Id] ASC)
);

