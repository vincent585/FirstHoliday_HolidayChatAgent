using HolidayChatAgent.Repository.DTOs;

namespace HolidayChatAgent.Repository.Interfaces
{
    public interface IHolidayRepository
    {
        Task<IEnumerable<HolidayDto>> GetAllHolidaysAsync();
    }
}
