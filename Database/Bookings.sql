CREATE TABLE [dbo].[Bookings]
(
	[BookingId] INT,
	[ClientId] INT,
	[TourName] NVARCHAR(100),
	[EventMonth] NVARCHAR(100),
	[EventDay] NVARCHAR(100),
	[EventYear] NVARCHAR(100),
	[Payment] MONEY,
	[DateBooked] NVARCHAR(100), 
    CONSTRAINT [PK_Bookings] PRIMARY KEY ([BookingId]), 
    CONSTRAINT [FK_Bookings_ToTable] FOREIGN KEY ([ClientID]) REFERENCES [Clients]([ClientID]), 
    CONSTRAINT [FK_Bookings_ToTable_1] FOREIGN KEY ([TourName]) REFERENCES [Tours]([TourName]), 
    CONSTRAINT [FK_Bookings_ToTable_2] FOREIGN KEY ([EventMonth],[EventDay],[EventYear]) REFERENCES [TourEvents]([EventMonth],[EventDay],[EventYear])
)
