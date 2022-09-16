using HolidayChatAgent.Services.Models.Domain;

namespace HolidayChatAgent.Models
{
    public class HolidayViewModel
    {
        public IEnumerable<HolidayDetail> Holidays { get; set; } = default!;
        public UserPreferences UserPreferences { get; set; } = default!;
    }
}
