CREATE TABLE [dbo].[Product] (
    [Id]              INT           IDENTITY (1, 1) NOT NULL,
    [Name]            VARCHAR (100) NOT NULL,
    [FK_CategoryId]   INT           NOT NULL,
    [Description]     VARCHAR (MAX) NULL,
    [Price]           FLOAT (53)    NOT NULL,
    [AddedDateTime]   DATETIME      NOT NULL,
    [UpdatedDateTime] DATETIME      NOT NULL,
    CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Product_Category] FOREIGN KEY ([FK_CategoryId]) REFERENCES [dbo].[Category] ([Id])
);



