using HolidayChatAgent.Repository.DTOs;
using HolidayChatAgent.Services.Models.Domain;

namespace HolidayChatAgent.Services.Interfaces
{
    public interface IHolidayFilter
    {
        IEnumerable<HolidayDto> FilterHolidays(IEnumerable<HolidayDto> holidays, UserPreferences preferences);
    }
}
