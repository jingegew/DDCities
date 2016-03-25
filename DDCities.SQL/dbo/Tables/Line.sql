CREATE TABLE [dbo].[Line] (
    [LineId] BIGINT        IDENTITY (100, 1) NOT NULL,
    [From]   VARCHAR (255) NOT NULL,
    [To]     VARCHAR (255) NOT NULL,
    PRIMARY KEY CLUSTERED ([LineId] ASC)
);

