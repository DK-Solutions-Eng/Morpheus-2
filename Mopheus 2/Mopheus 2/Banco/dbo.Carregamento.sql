CREATE TABLE [dbo].[Carregamento]
(
	[Id] NUMERIC(18) IDENTITY (1, 1) NOT NULL PRIMARY KEY,
    [fornecedor] VARCHAR(50) NULL, 
    [produto] VARCHAR(50) NULL, 
    [numero_nota] VARCHAR(50) NULL, 
    [peso_nota_fiscal] INT NULL, 
    [peso_real] INT NULL, 
    [peso_diferenca] INT NULL, 
    [tara] INT NULL, 
    [recebedor] VARCHAR(50) NULL, 
    [device] VARCHAR(50) NULL,
	[dateinsert] Datetime NULL,
	[dateupdate] Datetime NULL
)
