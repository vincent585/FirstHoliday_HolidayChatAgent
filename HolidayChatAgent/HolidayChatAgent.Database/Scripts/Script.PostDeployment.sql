/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
IF NOT EXISTS (SELECT 1 FROM [dbo].[Continents])
    INSERT INTO [dbo].[Continents] (Name)
    VALUES('Asia'), ('North America'), ('Europe'), ('Africa'), ('Australia'), ('Antarctica'), ('Arctic')

IF NOT EXISTS (SELECT 1 FROM [dbo].[Countries])
    INSERT INTO [dbo].[Countries] (Name)
    VALUES ('Indonesia'), 
    ('USA'), 
    ('Ireland'), 
    ('Morocco'), 
    ('Australia'), 
    ('The Maldives'), 
    ('France'), 
    ('South Africa'), 
    ('U.A.E'), 
    ('French Polynesia'),
    ('Croatia'),
    ('Scotland'),
    ('Italy'),
    ('Bhutan'),
    ('India'),
    ('New Zealand'),
    ('Cuba'),
    ('Japan'),
    ('Antarctica'),
    ('Greenland')

IF NOT EXISTS (SELECT 1 FROM [dbo].[Categories])
    INSERT INTO [dbo].[Categories] (Description)
    VALUES ('active'), ('lazy')

IF NOT EXISTS (SELECT 1 FROM [dbo].[TempRatings])
    INSERT INTO [dbo].[TempRatings] (Description)
    VALUES ('mild'), ('cold'), ('hot')

IF NOT EXISTS (SELECT 1 FROM [dbo].[Locations])
    INSERT INTO [dbo].[Locations] (Description)
    VALUES ('mountain'), ('city'), ('sea')


IF NOT EXISTS(SELECT 1 FROM [dbo].[Holidays])
    INSERT INTO [dbo].[Holidays] (HotelName, City, ContinentId, CountryId, CategoryId, StarRating, TempRatingId, LocationId, PricePerNight)
    VALUES 
    ('Uptown', 'Bali', 1, 1, 1, 3, 1, 1, 120),
    ('Relaxamax', 'New Orleans', 2, 2, 2, 4, 1, 2, 28),
    ('WindyBeach', 'Ventry', 3, 3, 1, 3, 1, 3, 42),
    ('Twighlight', 'Marrakech', 4, 4, 2, 5, 2, 1, 50),
    ('TooHot', 'Sydney', 5, 5, 2, 5, 3, 3, 67),
    ('Castaway', NULL, 4, 6, 2, 3, 1, 3, 120),
    ('Eiffel Park', 'Paris', 3, 7, 1, 4, 1, 2, 45),
    ('The Cape', 'Cape Town', 4, 8, 1, 4, 1, 3, 78),
    ('Desert Dreams', 'Dubai', 1, 9, 1, 4, 3, 1, 67),
    ('SeaViews', 'Bora Bora', 5, 10, 2, 3, 1, 3, 54),
    ('AppleCity', 'New York', 2, 2, 1, 3, 1, 2, 27),
    ('IslandHopper', 'Dubrovnik', 3, 11, 1, 5, 1, 3, 78),
    ('CastleTown', 'Edinburgh', 3, 12, 2, 3, 1, 2, 53),
    ('WineValley', 'Rome', 3, 13, 2, 5, 1, 2, 25),
    ('WearyTraveller', 'Paro Valley', 1, 14, 1, 5, 1, 1, 54),
    ('HotTimes', 'Jaipur', 1, 15, 2, 4, 3, 3, 67),
    ('ForestRetreat', 'Walkato', 5, 16, 1, 4, 1, 1, 89),
    ('Casablanca', 'Havana', 2, 17, 2, 5, 1, 2, 29),
    ('TechCity', 'Tokyo', 1, 18, 1, 3, 1, 2, 71),
    ('IceHotel', 'Base Maramblo', 6, 19, 1, 5, 2, 1, 270),
    ('NorthStar', NULL, 7, 20, 1, 5, 2, 1, 250)



