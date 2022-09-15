using AutoFixture;
using FluentAssertions;
using HolidayChatAgent.Repository.DTOs;
using HolidayChatAgent.Services.Models.Domain;
using HolidayChatAgent.Services.Services;
using NUnit.Framework;

namespace HolidayChatAgent.Tests.ServicesTests
{
    [TestFixture]
    public class HolidayFilterTests
    {
        private Fixture _fixture;
        private HolidayFilter _sut;

        [SetUp]
        public void Setup()
        {
            _fixture = new Fixture();
            _sut = new HolidayFilter();
        }

        [Test]
        public void FilterHolidays_WhenCalledWithMatchingUserPreferences_ReturnsFilteredHolidays()
        {
            var preferences = _fixture.Build<UserPreferences>().With(x => x.PricePerNight, "100").Create();
            var matchingHoliday = _fixture.Build<HolidayDto>()
                .With(x => x.PricePerNight, decimal.Parse(preferences.PricePerNight))
                .With(x => x.Category, preferences.Category)
                .With(x => x.TempRating, preferences.TempRating)
                .Create();

            var holidays = _fixture.CreateMany<HolidayDto>().ToList();
            holidays.Add(matchingHoliday);
            holidays.Add(matchingHoliday);

            var filtered = new List<HolidayDto> { matchingHoliday, matchingHoliday };

            var result = _sut.FilterHolidays(holidays, preferences);

            result.Should().BeEquivalentTo(filtered);
        }

        [Test]
        public void FilterHolidays_WhenCalledWithNoMatchingPreferences_ReturnsNoHolidays()
        {
            var preferences = _fixture.Build<UserPreferences>().With(x => x.PricePerNight, "100").Create();
            var holidays = _fixture.CreateMany<HolidayDto>();

            var result = _sut.FilterHolidays(holidays, preferences);

            result.Should().BeEmpty();
        }
    }
}
