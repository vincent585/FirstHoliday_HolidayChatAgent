namespace HolidayChatAgent.Repository.DTOs
{
    public class HolidayDto
    {
        public int Id { get; set; }
        public string City { get; set; } = default!;
        public string Continent { get; set; } = default!;
        public string Country { get; set; } = default!;
        public string Category { get; set; } = default!;
        public int StarRating { get; set; }
        public string TempRating { get; set; } = default!;
        public string Location { get; set; } = default!;
        public decimal PricePerNight { get; set; }
    }
}
