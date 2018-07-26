﻿/*
Script de implantação para Banco

Este código foi gerado por uma ferramenta.
As alterações feitas nesse arquivo poderão causar comportamento incorreto e serão perdidas se
o código for gerado novamente.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "Banco"
:setvar DefaultFilePrefix "Banco"
:setvar DefaultDataPath ""
:setvar DefaultLogPath ""

GO
:on error exit
GO
/*
Detecta o modo SQLCMD e desabilita a execução do script se o modo SQLCMD não tiver suporte.
Para reabilitar o script após habilitar o modo SQLCMD, execute o comando a seguir:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'O modo SQLCMD deve ser habilitado para executar esse script com êxito.';
        SET NOEXEC ON;
    END


GO
USE [master];


GO

IF (DB_ID(N'$(DatabaseName)') IS NOT NULL) 
BEGIN
    ALTER DATABASE [$(DatabaseName)]
    SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE [$(DatabaseName)];
END

GO
PRINT N'Criando $(DatabaseName)...'
GO
CREATE DATABASE [$(DatabaseName)] COLLATE SQL_Latin1_General_CP1_CI_AS
GO
USE [$(DatabaseName)];


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ANSI_NULLS ON,
                ANSI_PADDING ON,
                ANSI_WARNINGS ON,
                ARITHABORT ON,
                CONCAT_NULL_YIELDS_NULL ON,
                NUMERIC_ROUNDABORT OFF,
                QUOTED_IDENTIFIER ON,
                ANSI_NULL_DEFAULT ON,
                CURSOR_DEFAULT LOCAL,
                RECOVERY FULL,
                CURSOR_CLOSE_ON_COMMIT OFF,
                AUTO_CREATE_STATISTICS ON,
                AUTO_SHRINK OFF,
                AUTO_UPDATE_STATISTICS ON,
                RECURSIVE_TRIGGERS OFF 
            WITH ROLLBACK IMMEDIATE;
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_CLOSE ON 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ALLOW_SNAPSHOT_ISOLATION OFF;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET READ_COMMITTED_SNAPSHOT OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_UPDATE_STATISTICS_ASYNC OFF,
                PAGE_VERIFY NONE,
                DATE_CORRELATION_OPTIMIZATION OFF,
                DISABLE_BROKER,
                PARAMETERIZATION SIMPLE,
                SUPPLEMENTAL_LOGGING OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF IS_SRVROLEMEMBER(N'sysadmin') = 1
    BEGIN
        IF EXISTS (SELECT 1
                   FROM   [master].[dbo].[sysdatabases]
                   WHERE  [name] = N'$(DatabaseName)')
            BEGIN
                EXECUTE sp_executesql N'ALTER DATABASE [$(DatabaseName)]
    SET TRUSTWORTHY OFF,
        DB_CHAINING OFF 
    WITH ROLLBACK IMMEDIATE';
            END
    END
ELSE
    BEGIN
        PRINT N'As configurações de banco de dados não podem ser modificadas. Você deve ser um SysAdmin para aplicar essas configurações.';
    END


GO
IF IS_SRVROLEMEMBER(N'sysadmin') = 1
    BEGIN
        IF EXISTS (SELECT 1
                   FROM   [master].[dbo].[sysdatabases]
                   WHERE  [name] = N'$(DatabaseName)')
            BEGIN
                EXECUTE sp_executesql N'ALTER DATABASE [$(DatabaseName)]
    SET HONOR_BROKER_PRIORITY OFF 
    WITH ROLLBACK IMMEDIATE';
            END
    END
ELSE
    BEGIN
        PRINT N'As configurações de banco de dados não podem ser modificadas. Você deve ser um SysAdmin para aplicar essas configurações.';
    END


GO
ALTER DATABASE [$(DatabaseName)]
    SET TARGET_RECOVERY_TIME = 0 SECONDS 
    WITH ROLLBACK IMMEDIATE;


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET FILESTREAM(NON_TRANSACTED_ACCESS = OFF),
                CONTAINMENT = NONE 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_CREATE_STATISTICS ON(INCREMENTAL = OFF),
                MEMORY_OPTIMIZED_ELEVATE_TO_SNAPSHOT = OFF,
                DELAYED_DURABILITY = DISABLED 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET QUERY_STORE (QUERY_CAPTURE_MODE = ALL, DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_PLANS_PER_QUERY = 200, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 367), MAX_STORAGE_SIZE_MB = 100) 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET QUERY_STORE = OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
        ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
        ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
        ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET TEMPORAL_HISTORY_RETENTION ON 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF fulltextserviceproperty(N'IsFulltextInstalled') = 1
    EXECUTE sp_fulltext_database 'enable';


GO
PRINT N'Criando [dbo].[ItensReceita]...';


GO
CREATE TABLE [dbo].[ItensReceita] (
    [id]                                      NUMERIC (18) IDENTITY (1, 1) NOT NULL,
    [id_receita]                              INT          NOT NULL,
    [etapa]                                   VARCHAR (50) NULL,
    [processo]                                VARCHAR (50) NULL,
    [produto]                                 VARCHAR (50) NULL,
    [rele]                                    INT          NULL,
    [tipo_evento_anterior]                    VARCHAR (50) NULL,
    [tempo_espera_evento_anterior]            TIME (0)     NULL,
    [entrada_evento_anterior]                 VARCHAR (50) NULL,
    [status_entrada_digital_evento_anterior]  BIT          NULL,
    [temperatura_evento_anterior]             INT          NULL,
    [tipo_evento_posterior]                   VARCHAR (50) NULL,
    [pre_corte]                               VARCHAR (50) NULL,
    [corte]                                   VARCHAR (50) NULL,
    [tempo_on]                                INT          NULL,
    [tempo_off]                               INT          NULL,
    [limite_peso_seguranca_evento_posterior]  VARCHAR (50) NULL,
    [entrada_evento_posterior]                VARCHAR (50) NULL,
    [status_entrada_digital_evento_posterior] BIT          NULL,
    [temperatura_evento_posterior]            INT          NULL,
    [limite_temperatura_evento_posterior]     INT          NULL,
    [tempo_evento_posterior]                  TIME (0)     NULL,
    [tempo_segurança_evento_posterior]        TIME (0)     NULL,
    [tempo_limite_total]                      TIME (0)     NULL,
    [alerta_emergencia]                       BIT          NULL,
    [pausar_receita]                          BIT          NULL,
    [acionar_saida]                           INT          NULL,
    [saida_seguranca]                         BIT          NULL,
    [sequencia]                               INT          NULL,
    [dateinsert]                              DATETIME     NULL,
    [dateupdate]                              DATETIME     NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);


GO
PRINT N'Criando [dbo].[Receita]...';


GO
CREATE TABLE [dbo].[Receita] (
    [id]         NUMERIC (18) IDENTITY (1, 1) NOT NULL,
    [nome]       VARCHAR (50) NULL,
    [dateinsert] DATETIME     NULL,
    [dateupdate] DATETIME     NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);


GO
PRINT N'Criando [dbo].[TipoComando]...';


GO
CREATE TABLE [dbo].[TipoComando] (
    [id]         NUMERIC (18) IDENTITY (1, 1) NOT NULL,
    [nome]       VARCHAR (50) NULL,
    [tipo]       INT          NULL,
    [dateinsert] DATETIME     NULL,
    [dateupdate] DATETIME     NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);


GO
PRINT N'Criando [dbo].[TipoRele]...';


GO
CREATE TABLE [dbo].[TipoRele] (
    [id]         NUMERIC (18) IDENTITY (1, 1) NOT NULL,
    [nome]       VARCHAR (50) NULL,
    [dateinsert] DATETIME     NULL,
    [dateupdate] DATETIME     NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);


GO
PRINT N'Criando [dbo].[Rele]...';


GO
CREATE TABLE [dbo].[Rele] (
    [id]         NUMERIC (18) IDENTITY (1, 1) NOT NULL,
    [IO]         VARCHAR (50) NULL,
    [descricao]  VARCHAR (50) NULL,
    [tipo]       VARCHAR (50) NULL,
    [device]     VARCHAR (50) NULL,
    [dateinsert] DATETIME     NULL,
    [dateupdate] DATETIME     NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);


GO
PRINT N'Criando [dbo].[Comando]...';


GO
CREATE TABLE [dbo].[Comando] (
    [id]                NUMERIC (18) IDENTITY (1, 1) NOT NULL,
    [codigo_comando]    VARCHAR (50) NULL,
    [descricao_comando] VARCHAR (50) NULL,
    [tipo]              INT          NULL,
    [dateinsert]        DATETIME     NULL,
    [dateupdate]        DATETIME     NULL
);


GO
PRINT N'Criando [dbo].[Usuario]...';


GO
CREATE TABLE [dbo].[Usuario] (
    [id]         NUMERIC (18) IDENTITY (1, 1) NOT NULL,
    [usuario]    VARCHAR (50) NULL,
    [senha]      VARCHAR (50) NULL,
    [dateinsert] DATETIME     NULL,
    [dateupdate] DATETIME     NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);


GO
PRINT N'Criando [dbo].[Log]...';


GO
CREATE TABLE [dbo].[Log] (
    [id]             NUMERIC (18)  IDENTITY (1, 1) NOT NULL,
    [descricao_erro] VARCHAR (MAX) NULL,
    [data_execucao]  VARCHAR (20)  NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY];


GO
PRINT N'Criando [dbo].[Configuracao]...';


GO
CREATE TABLE [dbo].[Configuracao] (
    [id]            NUMERIC (18) IDENTITY (1, 1) NOT NULL,
    [porta_arduino] VARCHAR (50) NULL,
    [baud_rate]     INT          NULL,
    [dateinsert]    DATETIME     NULL,
    [dateupdate]    DATETIME     NULL
);


GO
DECLARE @VarDecimalSupported AS BIT;

SELECT @VarDecimalSupported = 0;

IF ((ServerProperty(N'EngineEdition') = 3)
    AND (((@@microsoftversion / power(2, 24) = 9)
          AND (@@microsoftversion & 0xffff >= 3024))
         OR ((@@microsoftversion / power(2, 24) = 10)
             AND (@@microsoftversion & 0xffff >= 1600))))
    SELECT @VarDecimalSupported = 1;

IF (@VarDecimalSupported > 0)
    BEGIN
        EXECUTE sp_db_vardecimal_storage_format N'$(DatabaseName)', 'ON';
    END


GO
ALTER DATABASE [$(DatabaseName)]
    SET MULTI_USER 
    WITH ROLLBACK IMMEDIATE;


GO
PRINT N'Atualização concluída.';


GO