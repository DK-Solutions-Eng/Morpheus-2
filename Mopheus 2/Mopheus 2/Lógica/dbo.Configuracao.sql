CREATE TABLE [dbo].[Configuracao] (
    [id]         NUMERIC (18) IDENTITY (1, 1) NOT NULL,
    [COM_port]   VARCHAR (50) NULL,
    [baud_rate]  INT          NULL,
    [dateinsert] DATETIME     NULL,
    [dateupdate] DATETIME     NULL, 
    CONSTRAINT [PK_Configuracao] PRIMARY KEY ([id])
)

