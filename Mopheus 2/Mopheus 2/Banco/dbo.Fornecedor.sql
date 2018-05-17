CREATE TABLE [dbo].[Fornecedor] (
    [id]			NUMERIC (18) IDENTITY (1, 1) NOT NULL,
    [nome_completo] VARCHAR (50) NULL,
    [nome_resumido] VARCHAR (50) NULL,
    [dateinsert]	DATETIME     NULL,
    [dateupdate]	DATETIME     NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);