using AutoFixture;
using AutoMapper;
using FluentAssertions;
using HolidayChatAgent.Repository.DTOs;
using HolidayChatAgent.Repository.Interfaces;
using HolidayChatAgent.Services.Interfaces;
using HolidayChatAgent.Services.Models.Domain;
using HolidayChatAgent.Services.Services;
using Moq;
using NUnit.Framework;
using System.Security.Cryptography.Xml;

namespace HolidayChatAgent.Tests.ServicesTests
{
    [TestFixture]
    public class HolidayServiceTests
    {
        private Fixture _fixture;
        private Mock<IHolidayRepository> _holidayRepositoryMock;
        private Mock<IMapper> _mapperMock;
        private Mock<IHolidayFilter> _holidayFilterMock;
        private HolidayService _sut;

        [SetUp]
        public void Setup()
        {
            _fixture = new Fixture();
            _mapperMock = new Mock<IMapper>();
            _holidayRepositoryMock = new Mock<IHolidayRepository>();
            _holidayFilterMock = new Mock<IHolidayFilter>();
            _sut = new HolidayService(_mapperMock.Object, _holidayRepositoryMock.Object, _holidayFilterMock.Object);
        }

        [Test]
        public void Constructor_WhenMapperParameterIsNull_ArgumentNullExceptionShouldBeThrown()
        {
            var constructor = () => new HolidayService(null, _holidayRepositoryMock.Object, _holidayFilterMock.Object);
            constructor.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("mapper");
        }

        [Test]
        public void Constructor_WhenRepositoryParameterIsNull_ArgumentNullExceptionShouldBeThrown()
        {
            var constructor = () => new HolidayService(_mapperMock.Object, null, _holidayFilterMock.Object);
            constructor.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("holidayRepository");
        }

        [Test]
        public void Constructor_WhenFilterParameterIsNull_ArgumentNullExceptionShouldBeThrown()
        {
            var constructor = () => new HolidayService(_mapperMock.Object, _holidayRepositoryMock.Object, null);
            constructor.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("holidayFilter");
        }

        [Test]
        public async Task GetAllHolidaysAsync_WhenCalled_CallsHolidayRepository()
        {
            await _sut.GetAllHolidaysAsync();

            _holidayRepositoryMock.Verify(x => x.GetAllHolidaysAsync(), Times.Once);
        }

        [Test]
        public async Task GetAllHolidaysAsync_WhenCalled_CallsMapper()
        {
            await _sut.GetAllHolidaysAsync();

            _mapperMock.Verify(x => x.Map<IEnumerable<HolidayDetail>>(It.IsAny<IEnumerable<HolidayDto>>()), Times.Once);
        }

        [Test]
        public async Task GetAllHolidaysAsync_WhenCalled_ReturnsTheMappedResponse()
        {
            var holidays = _fixture.CreateMany<HolidayDetail>().ToList();

            _mapperMock.Setup(x => x.Map<IEnumerable<HolidayDetail>>(It.IsAny<IEnumerable<HolidayDto>>())).Returns(holidays);

            var result = await _sut.GetAllHolidaysAsync();

            result.Should().BeEquivalentTo(holidays);
        }

        [Test]
        public async Task GetHolidayByIdAsync_WhenCalled_CallsHolidayRepository()
        {
            await _sut.GetHolidayByIdAsync(It.IsAny<int>());

            _holidayRepositoryMock.Verify(x => x.GetHolidayById(It.IsAny<int>()), Times.Once);
        }

        [Test]
        public async Task GetHolidayByIdAsync_WhenCalled_CallsMapper()
        {
            await _sut.GetHolidayByIdAsync(It.IsAny<int>());

            _mapperMock.Verify(x => x.Map<HolidayDetail>(It.IsAny<HolidayDto>()), Times.Once);
        }

        [Test]
        public async Task GetHolidayByIdAsync_WhenCalled_ReturnsTheMappedResponse()
        {
            var expectedHoliday = _fixture.Create<HolidayDetail>();

            _mapperMock.Setup(x => x.Map<HolidayDetail>(It.IsAny<HolidayDto>())).Returns(expectedHoliday);

            var result = await _sut.GetHolidayByIdAsync(It.IsAny<int>());

            result.Should().BeEquivalentTo(expectedHoliday);
        }

        [Test]
        public async Task GetRecommendedHolidaysAsync_WhenCalled_CallsHolidayRepository()
        {
            var preferences = _fixture.Create<UserPreferences>();
            await _sut.GetRecommendedHolidaysAsync(preferences);

            _holidayRepositoryMock.Verify(x => x.GetAllHolidaysAsync(), Times.Once);
        }

        [Test]
        public async Task GetRecommendedHolidaysAsync_WhenCalled_CallsHolidayFilter()
        {
            var preferences = _fixture.Create<UserPreferences>();
            await _sut.GetRecommendedHolidaysAsync(preferences);

            _holidayFilterMock.Verify(x => x.FilterHolidays(It.IsAny<IEnumerable<HolidayDto>>(), preferences), Times.Once);
        }

        [Test]
        public async Task GetRecommendedHolidaysAsync_WhenCalled_CallsMapper()
        {
            var preferences = _fixture.Create<UserPreferences>();
            await _sut.GetRecommendedHolidaysAsync(preferences);

            _mapperMock.Verify(x => x.Map<IEnumerable<HolidayDetail>>(It.IsAny<IEnumerable<HolidayDto>>()), Times.Once);
        }

        [Test]
        public async Task GetRecommendedHolidaysAsync_WhenCalled_ReturnsFilteredHolidays()
        {
            var preferences = new UserPreferences() { Category = "active", PricePerNight = "100", TempRating = "mild" };

            var holidaysToFilter = AnyHolidayDtos(preferences);

            var filtered = new List<HolidayDto>() { holidaysToFilter.First() };

            var expectedHolidays = AnyHolidayDetails(preferences);


            _holidayRepositoryMock.Setup(x => x.GetAllHolidaysAsync()).ReturnsAsync(holidaysToFilter);
            _holidayFilterMock.Setup(x => x.FilterHolidays(holidaysToFilter, preferences)).Returns(filtered);
            _mapperMock.Setup(x => x.Map<IEnumerable<HolidayDetail>>(filtered)).Returns(expectedHolidays);

            var result = await _sut.GetRecommendedHolidaysAsync(preferences);

            result.Should().BeEquivalentTo(expectedHolidays);
        }

        private IEnumerable<HolidayDto> AnyHolidayDtos(UserPreferences preferences)
        {
            var holidaysToFilter = new List<HolidayDto>()
            {
                new HolidayDto()
                {
                    Category = preferences.Category,
                    City = "Tokyo",
                    Country = "Japan",
                    Continent = "Asia",
                    HotelName = "Something",
                    Id = 1,
                    Location = "city",
                    PricePerNight = decimal.Parse(preferences.PricePerNight),
                    StarRating = 5,
                    TempRating = preferences.TempRating
                },
                new HolidayDto()
                {
                    Category = preferences.Category,
                    City = "somewhere",
                    Country = "not",
                    Continent = "here",
                    HotelName = "Something",
                    Id = 1,
                    Location = "city",
                    PricePerNight = decimal.Parse(preferences.PricePerNight) + 1000,
                    StarRating = 5,
                    TempRating = "cold"
                }
            };
            return holidaysToFilter;
        }

        private IEnumerable<HolidayDetail> AnyHolidayDetails(UserPreferences preferences)
        {
            var expectedHolidays = new List<HolidayDetail>()
            {
                new HolidayDetail()
                {
                    Category = preferences.Category,
                    City = "Tokyo",
                    Country = "Japan",
                    Continent = "Asia",
                    HotelName = "Something",
                    Id = 1,
                    Location = "city",
                    PricePerNight = decimal.Parse(preferences.PricePerNight),
                    StarRating = 5,
                    TempRating = preferences.TempRating
                },
            };

            return expectedHolidays;
        }
    }
}
