CREATE TABLE [dbo].[Rele] (
    [id]         NUMERIC (18) IDENTITY (1, 1) NOT NULL,
	[descricao]  VARCHAR (50) NULL,
    [device]     VARCHAR (50) NULL,
    [tipo]       VARCHAR (50) NULL,
    [IO]         VARCHAR (50) NULL,
    [dateinsert] DATETIME     NULL,
    [dateupdate] DATETIME     NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

