CREATE TABLE [dbo].[User] (
    [UserId]    BIGINT        IDENTITY (100, 1) NOT NULL,
    [FirstName] VARCHAR (255) NOT NULL,
    [LastName]  VARCHAR (255) NOT NULL,
    [Email]     VARCHAR (255) NOT NULL,
    [Phone]     VARCHAR (255) NOT NULL,
    PRIMARY KEY CLUSTERED ([UserId] ASC)
);

