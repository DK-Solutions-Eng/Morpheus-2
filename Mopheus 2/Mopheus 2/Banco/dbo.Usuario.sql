CREATE TABLE [dbo].[Usuario] (
    [Id]         NUMERIC          IDENTITY (1, 1) NOT NULL,
    [Nome]       VARCHAR (50) NULL,
    [login]      VARCHAR (50) NULL,
    [senha]      VARCHAR (50) NULL,
    [acesso]     VARCHAR (50) NULL,
    [dateinsert] DATETIME     NULL,
    [dateupdate] DATETIME     NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

