CREATE TABLE [dbo].[Materia_Prima] (
    [id]					NUMERIC (18) IDENTITY (1, 1) NOT NULL,
    [descricao_completa]	VARCHAR (50) NULL,
    [descricao_resumida]    VARCHAR (50) NULL,
	[codigo]				VARCHAR (50) NULL,
    [dateinsert]			DATETIME     NULL,
    [dateupdate]			DATETIME     NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);