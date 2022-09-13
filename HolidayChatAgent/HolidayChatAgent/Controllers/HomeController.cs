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
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IHolidayService holidayService, IMapper mapper)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _holidayService = holidayService ?? throw new ArgumentNullException(nameof(holidayService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IActionResult> Index()
        {
            var holidays = await _holidayService.GetAllHolidaysAsync();

            var holidayViewModel = _mapper.Map<IEnumerable<HolidayViewModel>>(holidays);

            return View(holidays);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}