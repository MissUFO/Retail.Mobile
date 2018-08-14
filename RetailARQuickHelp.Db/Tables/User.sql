CREATE TABLE [auth].[User] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [UserName]    NVARCHAR (255) NOT NULL,
    [FirstName]   NVARCHAR (255) NULL,
    [LastName]    NVARCHAR (255) NULL,
    [MiddleName]  NVARCHAR (255) NULL,
    [EmployeeId]  BIGINT         CONSTRAINT [DF_User_EmployeeId] DEFAULT ((0)) NOT NULL,
    [PhoneNumber] NVARCHAR (50)  NULL,
    [Email]       NVARCHAR (255) NULL,
    [StoreId]     INT            CONSTRAINT [DF_User_StoreId] DEFAULT ((1)) NOT NULL,
    [Status]      BIT            CONSTRAINT [DF_User_Status] DEFAULT ((1)) NOT NULL,
    [CreatedOn]   DATETIME       CONSTRAINT [DF_User_CreatedOn] DEFAULT (getdate()) NOT NULL,
    [ModifiedOn]  DATETIME       CONSTRAINT [DF_User_ModifiedOn] DEFAULT (getdate()) NOT NULL,
    [LastLoginOn] DATETIME       NULL,
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_User_Store] FOREIGN KEY ([StoreId]) REFERENCES [auth].[Store] ([Id]) ON DELETE CASCADE
);


GO
ALTER TABLE [auth].[User] NOCHECK CONSTRAINT [FK_User_Store];




GO
ALTER TABLE [auth].[User] NOCHECK CONSTRAINT [FK_User_Store];

