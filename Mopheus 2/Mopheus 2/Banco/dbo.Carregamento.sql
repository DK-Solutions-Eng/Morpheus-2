CREATE TABLE [dbo].[Carregamento] (
    [Id]               NUMERIC (18) IDENTITY (1, 1) NOT NULL,
    [fornecedor]       VARCHAR (50) NULL,
    [produto]          VARCHAR (50) NULL,
    [numero_nota]      VARCHAR (50) NULL,
    [peso_nota_fiscal] NUMERIC(10, 5)          NULL,
    [peso_real]        NUMERIC(10, 5)          NULL,
    [peso_diferenca]   NUMERIC(10, 5)          NULL,
    [tara]             NUMERIC(10, 5)          NULL,
    [recebedor]        VARCHAR (50) NULL,
    [device]           VARCHAR (50) NULL,
	[current_user]	   VARCHAR (50) NULL,
    [dateinsert]       DATETIME     NULL,
    [dateupdate]       DATETIME     NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

