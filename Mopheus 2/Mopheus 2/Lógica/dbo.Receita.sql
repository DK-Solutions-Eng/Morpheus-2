CREATE TABLE [dbo].[Receita] (
    [id_receita]   INT          NOT NULL,
    [name_receita] VARCHAR (50) NULL,
    [date_insert]  DATETIME     NULL,
    [date_update]  DATETIME     NULL,
    PRIMARY KEY CLUSTERED ([id_receita] ASC)
);

