CREATE TABLE [dbo].[DriverSchedule](
	[DriverScheduleId] BIGINT   IDENTITY (100, 1) NOT NULL,
    [UserId]        BIGINT   NOT NULL,
	[CarId]			BIGINT	 NOT NULL,
	[FromAddressId] BIGINT   NOT NULL,
	[ToAddressId]   BIGINT   NOT NULL,
    [LeaveAfter]     DATETIME NOT NULL,
    [LeaveBefore]       DATETIME NOT NULL,
    [NumberOfSeat]	INT NULL,
	[Fee]			MONEY NULL,
	[Repeats]		VARCHAR(255) NULL,
	[Comment]		TEXT NULL,
    [CreatedOn]     DATETIME DEFAULT (getdate()) NOT NULL,
    [LastUpdateOn]  DATETIME DEFAULT (getdate()) NULL,
	PRIMARY KEY CLUSTERED ([DriverScheduleId] ASC),
    CONSTRAINT [FK_DriverSchedule_ToFromAddressId] FOREIGN KEY ([FromAddressId]) REFERENCES [dbo].[Address] ([AddressId]),
	CONSTRAINT [FK_DriverSchedule_ToToAddressId] FOREIGN KEY ([ToAddressId]) REFERENCES [dbo].[Address] ([AddressId]),
    CONSTRAINT [FK_DriverSchedule_ToUser] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([UserId]),
    CONSTRAINT [FK_DriverSchedule_ToCar] FOREIGN KEY ([CarId]) REFERENCES [dbo].[Car] ([CarId])

);

