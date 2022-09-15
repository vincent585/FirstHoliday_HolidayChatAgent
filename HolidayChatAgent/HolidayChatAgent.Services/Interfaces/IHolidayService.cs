using HolidayChatAgent.Services.Models.Domain;

namespace HolidayChatAgent.Services.Interfaces
{
    public interface IHolidayService
    {
        Task<IEnumerable<HolidayDetail>> GetRecommendedHolidaysAsync(UserPreferences preferences);
        Task<IEnumerable<HolidayDetail>> GetAllHolidaysAsync();
    }
}
