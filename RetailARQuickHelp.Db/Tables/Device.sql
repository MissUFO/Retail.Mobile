CREATE TABLE [dbo].[Device] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [ImageUrl]    NVARCHAR (255) NULL,
    [Name]        NVARCHAR (255)  NOT NULL,
    [Model]       NVARCHAR (255)  NULL,
	[DeviceType]  INT            CONSTRAINT [DF_Device_DeviceType_1] DEFAULT ((0)) NOT NULL,
    [Description] NVARCHAR (2048) NULL,
    [CreatedOn]   DATETIME       CONSTRAINT [DF_Device_CreatedOn] DEFAULT (getdate()) NULL,
    [ModifiedOn]  DATETIME       CONSTRAINT [DF_Device_ModifiedOn] DEFAULT (getdate()) NULL,
    CONSTRAINT [PK_Device] PRIMARY KEY CLUSTERED ([Id] ASC)
);



