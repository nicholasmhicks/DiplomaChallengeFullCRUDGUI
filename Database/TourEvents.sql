CREATE TABLE [dbo].[TourEvents]
(
	[EventMonth] NVARCHAR(100),
	[EventDay] NVARCHAR(100),
	[EventYear] NVARCHAR(100),
	[TourName] NVARCHAR(100) NOT NULL,
	[Fee] MONEY,
    CONSTRAINT [PK_TourEvents] PRIMARY KEY ([EventMonth],[EventDay],[EventYear]), 
    CONSTRAINT [FK_TourEvents_ToTable] FOREIGN KEY ([TourName]) REFERENCES [Tours]([TourName])

)
