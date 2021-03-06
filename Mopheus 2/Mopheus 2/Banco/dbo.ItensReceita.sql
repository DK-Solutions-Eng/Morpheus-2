﻿CREATE TABLE [dbo].[ItensReceita] (
    [id]                                      NUMERIC (18)  IDENTITY (1, 1) NOT NULL,
    [sequencia]                               INT           NULL,
    [id_receita]                              INT           NOT NULL,
    [etapa]                                   VARCHAR (50)  NULL,
    [processo]                                VARCHAR (50)  NULL,
    [produto]                                 VARCHAR (50)  NULL,
    [rele]                                    VARCHAR (50)  NULL,
    [estado_saida]                            INT           NULL,
    [controle_velocidade]                     INT           NULL,
    [name_inversor]                           VARCHAR (50)  NULL,
    [addr_inversor]                           INT           NULL,
    [velocidade]                              INT           NULL,
    [tipo_evento_anterior]                    VARCHAR (50)  NULL,
    [tempo_espera_evento_anterior]            TIME (0)      NULL,
    [entrada_evento_anterior]                 VARCHAR (50)  NULL,
    [status_entrada_digital_evento_anterior]  INT           NULL,
    [setpoint_evento_anterior]                INT           NULL,
    [tipo_evento_posterior]                   VARCHAR (50)  NULL,
    [pre_corte]                               VARCHAR (50)  NULL,
    [corte]                                   VARCHAR (50)  NULL,
    [tempo_on]                                INT           NULL,
    [tempo_off]                               INT           NULL,
    [limite_peso_seguranca_evento_posterior]  VARCHAR (50)  NULL,
    [indicador_name]                          VARCHAR (50)  NULL,
    [indicador_addr]                          INT           NULL,
    [entrada_evento_posterior]                VARCHAR (50)  NULL,
    [status_entrada_digital_evento_posterior] INT           NULL,
    [setpoint_evento_posterior]               INT           NULL,
    [setpoint_limite_evento_posterior]        INT           NULL,
    [tempo_evento_posterior]                  TIME (0)      NULL,
    [tempo_limite_total]                      TIME (0)      NULL,
    [alerta_emergencia]                       INT           NULL,
    [pausar_receita]                          INT           NULL,
    [acionar_saida]                           INT           NULL,
    [saida_seguranca]                         VARCHAR(50)           NULL,
    [dateinsert]                              DATETIME2 (2) NULL,
    [dateupdate]                              DATETIME2 (2) NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

