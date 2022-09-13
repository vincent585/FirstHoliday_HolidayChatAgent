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

        public HolidayService(IMapper mapper, IHolidayRepository holidayRepository)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _holidayRepository = holidayRepository ?? throw new ArgumentNullException(nameof(holidayRepository));
        }

        public async Task<IEnumerable<HolidayDetail>> GetRecommendedHolidaysAsync()
        {
            var holidayDtos = await _holidayRepository.GetAllHolidaysAsync();

            // TODO - Create and implement a IHolidayFilter to call _holidayFilter.FilterHolidays(holidayDtos);

            return _mapper.Map<IEnumerable<HolidayDetail>>(holidayDtos);
        }
    }
}
