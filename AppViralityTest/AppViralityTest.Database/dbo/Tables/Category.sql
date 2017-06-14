CREATE TABLE [dbo].[Category] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [Name]        VARCHAR (50)  NOT NULL,
    [Description] VARCHAR (MAX) NULL,
    CONSTRAINT [PK_MST_Category] PRIMARY KEY CLUSTERED ([Id] ASC)
);

