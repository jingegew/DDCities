CREATE TABLE [dbo].[RideRequest] (
    [RideRequstId]  BIGINT   IDENTITY (100, 1) NOT NULL,
	[FromAddressId] BIGINT   NOT NULL,
	[ToAddressId]   BIGINT   NOT NULL,
    [UserId]        BIGINT   NOT NULL,
    [LeaveAfter]    DATETIME NOT NULL,
    [LeaveBefore]   DATETIME NOT NULL,
    [NumberOfRider] INT      NULL,
	[Comment]		TEXT NULL,
    [CreatedOn]     DATETIME DEFAULT (getdate()) NOT NULL,
    [LastUpdateOn]  DATETIME DEFAULT (getdate()) NULL,
    CONSTRAINT [UPKCLU_xref_RideRequest_Pkey] PRIMARY KEY CLUSTERED ([RideRequstId] ASC),
    CONSTRAINT [FK_RideRequest_ToFromAddressId] FOREIGN KEY ([FromAddressId]) REFERENCES [dbo].[Address] ([AddressId]),
	CONSTRAINT [FK_RideRequest_ToToAddressId] FOREIGN KEY ([ToAddressId]) REFERENCES [dbo].[Address] ([AddressId]),
    CONSTRAINT [FK_RideRequest_ToUser] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([UserId])
);

