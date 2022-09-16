CREATE TABLE [dbo].[Holidays]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [City] NVARCHAR(100) NULL, 
    [ContinentId] INT NOT NULL, 
    [CountryId] INT NOT NULL, 
    [CategoryId] INT NOT NULL, 
    [StarRating] INT NULL, 
    [TempRatingId] INT NOT NULL, 
    [LocationId] INT NOT NULL, 
    [PricePerNight] DECIMAL(9, 2) NOT NULL, 
    [HotelName] NVARCHAR(100) NOT NULL, 
    CONSTRAINT [FK_Holidays_Continents_ContinentId] FOREIGN KEY ([ContinentId]) REFERENCES [Continents]([Id]),
    CONSTRAINT [FK_Holidays_Countries_CountryId] FOREIGN KEY ([CountryId]) REFERENCES [Countries]([Id]),
    CONSTRAINT [FK_Holidays_Categories_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [Categories]([Id]),
    CONSTRAINT [FK_Holidays_TempRatings_TempRatingId] FOREIGN KEY ([TempRatingId]) REFERENCES [TempRatings]([Id]),
    CONSTRAINT [FK_Holidays_Locations_LocationId] FOREIGN KEY ([LocationId]) REFERENCES [Locations]([Id])
)
