CREATE TABLE [dbo].[Network] (
    [Id]         NUMERIC (18) IDENTITY (1, 1) NOT NULL,
    [model]      VARCHAR (50) NULL,
    [name]       VARCHAR (50) NULL,
    [addr]       INT          NULL,
    [baud_rate]  INT          NULL,
    [parent]     VARCHAR (50) NULL,
	[full_name]  VARCHAR (50) NULL,
    [dateinsert] DATETIME     NULL,
    [dateupdate] DATETIME     NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

