using HolidayChatAgent.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using AutoMapper;
using HolidayChatAgent.Services.Interfaces;

namespace HolidayChatAgent.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHolidayService _holidayService;
        private readonly IMapper _mapper;

        public HomeController(IHolidayService holidayService, IMapper mapper)
        {
            _holidayService = holidayService ?? throw new ArgumentNullException(nameof(holidayService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IActionResult> Index()
        {
            var holidays = await _holidayService.GetAllHolidaysAsync();

            var holidayViewModel = _mapper.Map<IEnumerable<HolidayViewModel>>(holidays);

            return View("Index", holidayViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> RecommendedHolidays(UserPreferences preferences)
        {
            HttpContext.Session.Set("Preferences", preferences);

            var recommendations = await _holidayService.GetRecommendedHolidaysAsync();

            var holidayViewModel = _mapper.Map<IEnumerable<HolidayViewModel>>(recommendations);

            return View(holidayViewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}