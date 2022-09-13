using HolidayChatAgent.Repository.DTOs;
using HolidayChatAgent.Services.Interfaces;
using Microsoft.AspNetCore.Http;

namespace HolidayChatAgent.Services.Services
{
    public class HolidayFilter : IHolidayFilter
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HolidayFilter(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IEnumerable<HolidayDto>> FilterHolidaysAsync(IEnumerable<HolidayDto> holidays)
        {
            var session = _httpContextAccessor.HttpContext.Session;

            throw new NotImplementedException();
        }
    }
}
