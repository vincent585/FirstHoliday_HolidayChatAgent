using HolidayChatAgent.Repository.DTOs;
using HolidayChatAgent.Services.Interfaces;
using HolidayChatAgent.Services.Models.Domain;

namespace HolidayChatAgent.Services.Services
{
    public class HolidayFilter : IHolidayFilter
    {
        public  IEnumerable<HolidayDto> FilterHolidays(IEnumerable<HolidayDto> holidays, UserPreferences preferences)
        {
            var filteredHolidays = holidays.Where(x =>
                x.Category == preferences.Category && x.TempRating == preferences.TempRating &&
                x.PricePerNight <= decimal.Parse(preferences.PricePerNight));

            return filteredHolidays;
        }
    }
}
