namespace HolidayChatAgent.Services.Models.Domain
{
    public class UserPreferences
    {
        public string Category { get; set; } = string.Empty;
        public string TempRating { get; set; } = string.Empty;
        public string PricePerNight { get; set; } = string.Empty;
    }
}
