CREATE TABLE [dbo].[Car](
    [CarId]    BIGINT        IDENTITY (100, 1) NOT NULL,
    [Make] VARCHAR (255) NOT NULL,
    [Model]  VARCHAR (255) NOT NULL,
    [Year]     INT NOT NULL,
    [Type]     SMALLINT NOT NULL,
    PRIMARY KEY CLUSTERED ([CarId] ASC)
);

