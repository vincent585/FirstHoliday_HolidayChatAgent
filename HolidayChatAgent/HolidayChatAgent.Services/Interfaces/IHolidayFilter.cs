using HolidayChatAgent.Repository.DTOs;

namespace HolidayChatAgent.Services.Interfaces
{
    public interface IHolidayFilter
    {
        Task<IEnumerable<HolidayDto>> FilterHolidaysAsync(IEnumerable<HolidayDto> holidays);
    }
}
