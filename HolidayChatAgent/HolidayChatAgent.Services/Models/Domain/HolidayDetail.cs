namespace HolidayChatAgent.Services.Models.Domain
{
    public class HolidayDetail
    {
        public int Id { get; set; }
        public string HotelName { get; set; } = default!;
        public string? City { get; set; }
        public string Continent { get; set; } = default!;
        public string Country { get; set; } = default!;
        public string Category { get; set; } = default!;
        public int? StarRating { get; set; }
        public string TempRating { get; set; } = default!;
        public string Location { get; set; } = default!;
        public decimal PricePerNight { get; set; }
    }
}
