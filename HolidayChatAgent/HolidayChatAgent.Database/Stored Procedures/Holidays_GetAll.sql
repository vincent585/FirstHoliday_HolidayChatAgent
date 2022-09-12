CREATE PROCEDURE [dbo].[Holidays_GetAll]
AS

SELECT
	HotelName,
	City,
	CONT.Name AS Continent,
	CTRY.Name AS Country,
	CAT.Description AS Category,
	StarRating,
	TR.Description AS TempRating,
	L.Description AS Location,
	PricePerNight

	
FROM
	[dbo].[Holidays] H
	INNER JOIN [dbo].[Continents] CONT ON CONT.Id = H.ContinentId
	INNER JOIN [dbo].[Countries] CTRY ON CTRY.Id = H.CountryId
	INNER JOIN [dbo].[Categories] CAT ON CAT.Id = H.CategoryId
	INNER JOIN [dbo].[TempRatings] TR ON TR.Id = H.TempRatingId
	INNER JOIN [dbo].[Locations] L ON L.Id = H.LocationId