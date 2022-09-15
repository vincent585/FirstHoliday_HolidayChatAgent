using AutoMapper;
using HolidayChatAgent.Repository.Interfaces;
using HolidayChatAgent.Services.Interfaces;
using HolidayChatAgent.Services.Models.Domain;

namespace HolidayChatAgent.Services.Services
{
    public class HolidayService : IHolidayService
    {
        private readonly IMapper _mapper;
        private readonly IHolidayRepository _holidayRepository;
        private readonly IHolidayFilter _holidayFilter;

        public HolidayService(IMapper mapper, IHolidayRepository holidayRepository, IHolidayFilter holidayFilter)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _holidayRepository = holidayRepository ?? throw new ArgumentNullException(nameof(holidayRepository));
            _holidayFilter = holidayFilter ?? throw new NotImplementedException(nameof(holidayFilter));
        }

        public async Task<IEnumerable<HolidayDetail>> GetRecommendedHolidaysAsync(UserPreferences preferences)
        {
            var holidayDtos = await _holidayRepository.GetAllHolidaysAsync();

            var recommendedHolidays = _holidayFilter.FilterHolidays(holidayDtos, preferences);

            return _mapper.Map<IEnumerable<HolidayDetail>>(recommendedHolidays);
        }

        public async Task<IEnumerable<HolidayDetail>> GetAllHolidaysAsync()
        {
            return _mapper.Map<IEnumerable<HolidayDetail>>(await _holidayRepository.GetAllHolidaysAsync());
        }

        public async Task<HolidayDetail> GetHolidayByIdAsync(int id)
        {
            return _mapper.Map<HolidayDetail>(await _holidayRepository.GetHolidayById(id));
        }
    }
}
