CREATE TABLE [dbo].[Address] (
    [AddressId] BIGINT        IDENTITY (100, 1) NOT NULL,
	[Name]		VARCHAR (255) NULL,
    [Address]   VARCHAR (255) NOT NULL,
    [City]     VARCHAR (255) NOT NULL,
	[State]     VARCHAR (255) NOT NULL,
	[ZipCode]     VARCHAR (255) NOT NULL,
    PRIMARY KEY CLUSTERED ([AddressId] ASC)
);

